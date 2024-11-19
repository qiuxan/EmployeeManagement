import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Employee } from '../../models/employee';
import { EmployeeService } from '../employee.service';
import { Router, ActivatedRoute, ParamMap} from '@angular/router';
import { CommonModule } from '@angular/common';
import { HttpErrorResponse } from '@angular/common/http';
@Component({
  selector: 'app-employee-form',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './employee-form.component.html',
  styleUrl: './employee-form.component.css'
})
export class EmployeeFormComponent implements OnInit {

  /**
   *
   */
  constructor
  (
    private employeeService: EmployeeService, 
    private router: Router,
    private route: ActivatedRoute
  ) {}

  employee: Employee = {
    id: 0,
    email: '',
    phone: '',
    firstName: '',
    lastName: '',
    position: ''
  }

  isEditing: boolean = false;
  errorMessage: string = '';

  onSubmit():void {

    if(this.isEditing) {
      this.employeeService.updateEmployee(this.employee)
      .subscribe({
        next: () => {
          this.router.navigate(['/']);
        },
        error: (error:HttpErrorResponse) => {
          this.errorMessage = `Error during updating: ${error.status} - ${error.message}`;
        }
      });
      return;
    }else{
      this.employeeService.createEmployee(this.employee)
        .subscribe({
          next: () => {
            this.router.navigate(['/']);
          },
          error: (error:HttpErrorResponse) => {
            this.errorMessage = `Error during creating: ${error.status} - ${error.message}`;
        }});
    }

   
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe((params) => {
      const id = params.get('id');
      if(id) {
        this.isEditing = true;
        this.employeeService.getEmployeeById(+id)
        .subscribe({
          next: (data: Employee) => {
            this.employee = data;
          },
          error: (error: HttpErrorResponse) => {
            this.errorMessage = `Error: ${error.status} - ${error.message}`;
          }
        });
      }
    });
    
  }

}
