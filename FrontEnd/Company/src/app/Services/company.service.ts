import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Company } from '../Models/company';

@Injectable({
  providedIn: 'root'
})
export class CompanyService {
  private http: HttpClient;
  
  constructor(http:HttpClient) {
    this.http = http
   }

   public GetCompanies(): Observable<Company[]> {
    return this.http.get<Company[]>("https://localhost:44346/api/CompanyModels");
  }
}
