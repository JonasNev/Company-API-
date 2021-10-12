import { Employee } from 'src/app/Models/employee';
import { EmployeeService } from 'src/app/Services/employee.service';
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { CompanyService } from 'src/app/Services/company.service';
import { Company } from 'src/app/Models/company';
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
    public editCustomer:false;
    public FormHeader: string;

  public employees: Employee[] = [
    {id: 0, firstName: "Jonas",lastName: "Nevinskas", sex: "Male", companyId:0},
  ];
  public companies: Company[];

  public employeeForUpdate: Employee;
  private employeeService: EmployeeService
  private companyService: CompanyService

  constructor(employeeService: EmployeeService, companyService: CompanyService) { 
    this.employeeService = employeeService
    this.companyService = companyService;
  }

  ngOnInit(): void {
    this.employeeService.GetEmployees().subscribe((employeesFromApi) =>{
      this.employees = employeesFromApi
    })
    this.companyService.GetCompanies().subscribe((employeesFromApi) =>{
      this.companies = employeesFromApi
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
  public updateEmployee() : void{
    var employee: Employee = {
      id: this.id!,
      firstName: this.firstName,
      lastName: this.lastName,
      sex: this.sex,
      companyId: this.companyId!
    }
    this.employeeService.UpdateEmployee(employee).subscribe(() => {
      this.employeeService.GetEmployees().subscribe((employeesFromApi) =>{
        this.employees = employeesFromApi
      })
    }
    )
  }

  ShowRegForm=function(employee)  
  {  
    this.editCustomer=true;  
    if(employee!=null)  
    {  
      this.SetValuesForEdit(employee)  
      document.getElementById("btn1").removeAttribute("disabled");
      document.getElementById("btn2").setAttribute("disabled","disabled");
    }  
    else{  
      this.ResetValues();  
    }  
  }  

  EnableForm=function(){
    this.editCustomer=true;
    this.ResetValues();
    
  }

  SetValuesForEdit=function(employee)  
{  
  this.firstName=employee.firstName;  
  this.lastName=employee.lastName;  
  this.sex=employee.sex;  
  this.id=employee.id;  
  this.companyId = employee.companyId;
  this.FormHeader="Edit"  
}
ResetValues(){  
  this.firstName="";  
  this.lastName="";  
  this.sex="";  
  this.companyId=null;
  this.id=null;    
}  
}
