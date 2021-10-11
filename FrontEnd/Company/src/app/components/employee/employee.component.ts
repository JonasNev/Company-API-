import { Employee } from 'src/app/Models/employee';
import { EmployeeService } from 'src/app/Services/employee.service';
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {

    public title:string = "Employees";
    public id?: number;
    public firstName: string = "";
    public lastName: string = "";
    public sex: string = "";
    public companyId?: number;

  public employees: Employee[] = [
    {id: 0, firstName: "Jonas",lastName: "Nevinskas", sex: "Male", companyId:0},
  ];

  private employeeService: EmployeeService

  constructor(employeeService: EmployeeService) { 
    this.employeeService = employeeService
  }

  ngOnInit(): void {
    this.employeeService.GetEmployees().subscribe((employeesFromApi) =>{
      this.employees = employeesFromApi
    })
  }
  public addEmployee() : void {
    var employee: Employee = {
      id: this.id!,
      firstName: this.firstName,
      lastName: this.lastName,
      sex: this.sex,
      companyId: this.companyId!
    }
    this.employeeService.AddEmployee(employee).subscribe(() => {
      this.employees.push(employee);
    });
  }
  public deleteEmployee(employee) : void{
    this.employeeService.DeleteEmployee(employee).subscribe(() => {
      this.employees = this.employees.filter(obj => obj !== employee);
    })
  }
  public updateEmployee(employee) : void{
    this.employeeService.UpdateEmployee(employee).subscribe(() => {
      this.employees = this.employees.filter(obj => obj !== employee);
      this.employees.push(employee);
    }
    )
  }
}
