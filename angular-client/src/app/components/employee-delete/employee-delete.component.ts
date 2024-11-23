import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EmployeeService } from '../../services/employee.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
@Component({
  selector: 'app-employee-delete',
  imports: [CommonModule, FormsModule],
  templateUrl: './employee-delete.component.html',
  styleUrls: ['./employee-delete.component.css'],
})
export class EmployeeDeleteComponent implements OnInit {
  employeeId: string = '';
  private error: boolean = false;
  constructor(
    private employeeService: EmployeeService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.employeeId = this.route.snapshot.paramMap.get('id') ?? '';
  }

  deleteEmployee(): void {
    this.employeeService.deleteEmployee(this.employeeId).subscribe({
      next: () => {
        this.router.navigate(['/employees/']);
      },
      error: (err) => {
        this.error = true;
        console.log(err);
        displayErrorMessages(err.error);
      },
    });
  }

  dontDelete():void{
    this.router.navigate(['/employees/']);
  }
}

function displayErrorMessages(errors: string[]): void {
  const errorMessage = errors.join();
  alert(errorMessage);
}
