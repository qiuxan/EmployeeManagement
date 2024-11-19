import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../employee.service';
import { Employee } from '../../models/employee';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
@Component({
  selector: 'employee-table',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './employee-table.component.html',
  styleUrl: './employee-table.component.css'
})
export class EmployeeTableComponent implements OnInit {
  employees: Employee[] = [];
  constructor(private employeeService: EmployeeService, private router: Router) { }
  ngOnInit() {
    this.employeeService.getEmployees().subscribe((data:Employee[]) => {
      this.employees = data;
      console.log({data});
    });
  }

  deleteEmployee(id: number) {
    this.employeeService.deleteEmployee(id)
    .subscribe({
      next: () => {
        this.employees = this.employees.filter(e => e.id !== id);
      },
      error: (error) => {
        console.log({error});
      }
    });

  }

  editEmployee(id: number) {
    this.router.navigate(['/edit', id]);
  }
}
