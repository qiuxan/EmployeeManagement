import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Employee } from '../../models/employee';
import { EmployeeService } from '../employee.service';
@Component({
  selector: 'app-employee-form',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './employee-form.component.html',
  styleUrl: './employee-form.component.css'
})
export class EmployeeFormComponent {

  /**
   *
   */
  constructor(private employeeService: EmployeeService) {
    
  }

  employee: Employee = {
    id: 0,
    email: '',
    phone: '',
    firstName: '',
    lastName: '',
    position: ''
  }

  onSubmit():void {
    this.employeeService.createEmployee(this.employee)
    .subscribe((result) => {
      console.log({result});
    });
  }

}
