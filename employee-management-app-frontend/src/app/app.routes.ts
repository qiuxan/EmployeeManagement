import { Routes } from '@angular/router';

import { EmployeeFormComponent } from './employee-form/employee-form.component';
import { EmployeeTableComponent } from './employee-table/employee-table.component';

export const routes: Routes = [
    {path:'',component:EmployeeTableComponent},
    {'path':'create',component:EmployeeFormComponent},
    {'path':'edit/:id',component:EmployeeFormComponent},
    {'path':'employee',redirectTo:'',pathMatch:'full'},
];
