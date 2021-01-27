import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { EmployeeService } from 'src/app/services/employee.service'
import { Employee } from '../models/employee';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  constructor(
    private employeeService: EmployeeService,
    private formBuilder: FormBuilder
  ) { }

  employees: Employee[]
  employeeId: number

  onSubmit() {
    debugger
    if (this.employeeId == 0 || this.employeeId == undefined) {
      this.getAllEmployees()
    } else {
      this.getEmployeeById(this.employeeId)
    }
  }

  getAllEmployees() {
    this.employeeService
      .getAllEmployees()
      .subscribe((data: Employee[]) => {
        console.log(data)
        this.employees = data
      });
  }

  getEmployeeById(id: number) {
    this.employeeService
      .getEmployeeByID(id)
      .subscribe((data: Employee) => {
        console.log(data)
        this.employees = []
        this.employees[0] = data
      });
  }
}
