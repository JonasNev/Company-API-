import { Component, OnInit } from '@angular/core';
import { Employee } from 'src/app/Models/employee';
import { Company } from 'src/app/Models/company';
import { CompanyService } from 'src/app/Services/company.service';
import { EmployeeService } from 'src/app/Services/employee.service';

@Component({
  selector: 'app-company',
  templateUrl: './company.component.html',
  styleUrls: ['./company.component.sass']
})
export class CompanyComponent implements OnInit {

  public id?: number;
  public name: string = "";
  private companyService: CompanyService;

  public companies: Company[] = []
  constructor(companyService: CompanyService) {
    this.companyService = companyService;
   }

  ngOnInit(): void {
    this.companyService.GetCompanies().subscribe((companiesFromApi) =>{
      this.companies = companiesFromApi;
  })
}
}
