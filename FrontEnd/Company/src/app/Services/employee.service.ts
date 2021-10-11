import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Employee } from '../Models/employee'
@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  private http: HttpClient;
  
  constructor(http:HttpClient) {
    this.http = http
   }

   public GetEmployees(): Observable<Employee[]> {
    return this.http.get<Employee[]>("https://localhost:44346/api/EmployeeModels");
  }

  public AddEmployee(employee:Employee): Observable<Employee>{
    return this.http.post<Employee>("https://localhost:44346/api/EmployeeModels", employee);
  }
  public DeleteEmployee(employee: Employee): Observable<Employee> {
    const url = `https://localhost:44346/api/EmployeeModels/${employee.id}`;
    return this.http.delete<Employee>(url);
  }

  public UpdateEmployee(employee: Employee) : Observable<Employee> {
    return this.http.put<Employee>(`https://localhost:44346/api/EmployeeModels/${employee.id}`, employee)
  }
}
