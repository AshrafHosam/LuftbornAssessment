import { Component } from '@angular/core';
import { EmployeeService } from '../../services/employee.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
@Component({
  selector: 'app-employee-add',
  imports: [CommonModule, FormsModule],
  templateUrl: './employee-add.component.html',
  styleUrls: ['./employee-add.component.css'],
})
export class EmployeeAddComponent {
  employee = { name: '', title: '', departmentCategory: '' };
  private error: boolean = false;
  constructor(
    private employeeService: EmployeeService,
    private router: Router
  ) {}

  addEmployee(): void {
    this.employeeService.addEmployee(this.employee).subscribe({
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
