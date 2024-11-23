import { Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { EmployeeListComponent } from './components/employee-list/employee-list.component';
import { EmployeeAddComponent } from './components/employee-add/employee-add.component';
import { EmployeeEditComponent } from './components/employee-edit/employee-edit.component';
import { EmployeeDeleteComponent } from './components/employee-delete/employee-delete.component';

export const routes: Routes = [
  { path: '', redirectTo: '/employees', pathMatch: 'full' },
  { path: 'employees', component: EmployeeListComponent },
  { path: 'employees/add', component: EmployeeAddComponent },
  { path: 'employees/edit/:id', component: EmployeeEditComponent },
  { path: 'employees/delete/:id', component: EmployeeDeleteComponent },
];
