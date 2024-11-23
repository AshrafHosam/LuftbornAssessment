import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EmployeeService } from '../../services/employee.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
@Component({
  selector: 'app-employee-edit',
  imports: [CommonModule, FormsModule],
  templateUrl: './employee-edit.component.html',
  styleUrls: ['./employee-edit.component.css'],
})
export class EmployeeEditComponent implements OnInit {
  employee: any = { id: '', name: '', title: '', departmentCategory: '' };
  private error: boolean = false;
  constructor(
    private employeeService: EmployeeService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id') ?? '';
    this.employeeService.getEmployeeById(id).subscribe((data) => {
      this.employee = data;
    });
  }

  updateEmployee(): void {
    this.employeeService.updateEmployee(this.employee).subscribe({
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
}

function displayErrorMessages(errors: string[]): void {
  const errorMessage = errors.join();
  alert(errorMessage);
}