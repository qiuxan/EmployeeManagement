import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Employee } from '../../models/employee';
import { EmployeeService } from '../employee.service';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { HttpErrorResponse } from '@angular/common/http';
@Component({
  selector: 'app-employee-form',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './employee-form.component.html',
  styleUrl: './employee-form.component.css'
})
export class EmployeeFormComponent {

  /**
   *
   */
  constructor(private employeeService: EmployeeService, private router: Router) {
    
  }

  employee: Employee = {
    id: 0,
    email: '',
    phone: '',
    firstName: '',
    lastName: '',
    position: ''
  }

  errorMessage: string = '';

  onSubmit():void {
    this.employeeService.createEmployee(this.employee)
    .subscribe({
      next: () => {
        this.router.navigate(['/']);
      },
      error: (error:HttpErrorResponse) => {
      //  console.log({error})
        this.errorMessage = `Error: ${error.status} - ${error.message}`;
      }
    });
  }

}
