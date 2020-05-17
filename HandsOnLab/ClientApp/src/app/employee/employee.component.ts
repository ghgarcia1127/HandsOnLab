import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html'
})
export class EmployeeComponent {
  public employees: Employee[];
  public employee: Employee;
  public loading: boolean;
  public identifier: number;

  public url: string;

  constructor(protected httpClient: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.url = baseUrl;
    this.loading = false;
  }

  GetEmployees() {
    this.loading = true;
    this.employees = null;
    this.employee = null;
    if (!this.identifier) {
      this.httpClient.get<Employee[]>(this.url + 'employee').subscribe(result => {
        this.employees = result;
        this.loading = false;
      }, error => console.error(error));
    }
    else {
      this.httpClient.get<Employee>(this.url + 'employee/' + this.identifier).subscribe(result => {
        this.employee = result;
        this.loading = false;
      }, error => console.error(error));
    }


  }
}

interface Employee {
  id: number;
  name: string;
  contractTypeName: string;
  roleId: number;
  roleName: string;
  roleDescription: string;
  monthlySalary: number;
  hourlySalary: number;
  annualSalary: number;
}

