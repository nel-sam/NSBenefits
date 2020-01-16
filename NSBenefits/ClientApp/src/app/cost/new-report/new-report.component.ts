import { Component, OnInit } from '@angular/core';
import { Dependent, Employee, CostAnalysis } from 'src/app/interfaces/interfaces';
import { EmployeeService } from 'src/app/services/employee-service';
import { VirtualTimeScheduler } from 'rxjs';

@Component({
  selector: 'app-new-report',
  templateUrl: './new-report.component.html',
  styleUrls: ['./new-report.component.scss']
})
export class NewReportComponent implements OnInit {
  public employeeFirstName: string;
  public employeeLastName: string;
  public dependentFirstName: string;
  public dependentLastName: string;
  public dependents: Dependent[] = [];
  public selectedEmployee: Employee;
  public costAnalysis: CostAnalysis;

  constructor(private employeeService: EmployeeService) { }

  ngOnInit() {
  }

  public addDependent(): void {
    if (!this.dependentFirstName) {
      alert('First name is required');
      return;
    }

    if (!this.dependentLastName) {
      alert('Last name is required');
      return;
    }

    const matches = this.dependents.filter(e =>
          e.firstName === this.dependentFirstName
          && e.lastName === this.dependentLastName);

    if (matches.length > 0) {
      alert('That dependent was already added');
      return;
    }


    this.dependents.push({
      firstName: this.dependentFirstName,
      lastName: this.dependentLastName
    } as Dependent);

    this.dependentFirstName = this.dependentLastName = '';
  }

  public runReport(): void {
    if (!this.employeeFirstName) {
      alert('The employee\'s first name is required');
      return;
    }

    if (!this.employeeLastName) {
      alert('The employee\'s last name is required');
      return;
    }

    this.selectedEmployee = {
      firstName: this.employeeFirstName,
      lastName: this.employeeLastName,
      dependents: this.dependents,
      salary: 2000
    } as Employee;

    this.costAnalysis = this.employeeService.calculateCost(this.selectedEmployee);
  }

  public clearValues(): void {
    this.costAnalysis = null
    this.dependents = [];
    this.employeeFirstName = '';
    this.employeeLastName = '';
  }
}
