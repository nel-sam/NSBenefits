import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Employee, AppState } from '../interfaces/interfaces';
import { EmployeeService } from '../services/employee-service';
import { Store } from '@ngrx/store';
import * as EmployeeActions from './../state/actions/employee.actions'

@Component({
  selector: 'app-cost',
  templateUrl: './cost.component.html',
  styleUrls: [ './cost.component.scss' ]
})
export class CostComponent implements OnInit {
  public employees$: Observable<Employee[]>;
  public selectedEmployee: Employee;

  public paychecksPerYear: number = 26;
  public discountPercentage: number = 0.1;
  public employeeBaseCost: number = 1000;
  public dependentBaseCost: number = 500;
  public employeeCost: number;
  public employeeDiscountApplied: boolean;
  public dependentCost: number;
  public dependentDiscountsApplied: number;
  public totalYearlyCost: number;
  public totalCostPerPayPeriod: number;

  constructor(
    private store: Store<AppState>,
    private employeeService: EmployeeService) {
    this.employees$ = this.store.select('employees');
  }

  ngOnInit() {
    this.employeeService.getAll()
      .subscribe(result => {
          this.store.dispatch(new EmployeeActions.LoadAllEmployees(result))
      }, error => {
        alert('Error occurred ' + error);
      });
  }

  public calculateCost(employee: Employee) {
    this.clearCosts();

    if (employee.firstName[0] === 'A') {
      this.employeeCost = this.employeeBaseCost - (this.employeeBaseCost * this.discountPercentage);
      this.employeeDiscountApplied = true;
    }

    for (let dependent of employee.dependents) {
      this.dependentCost += this.dependentBaseCost;

      if (dependent.firstName[0] === 'A') {
        this.dependentCost -= this.dependentBaseCost * this.discountPercentage;
        dependent.discountApplies = true;
        this.dependentDiscountsApplied++;
      }
    }

    this.totalYearlyCost = this.employeeCost + this.dependentCost;
    this.totalCostPerPayPeriod = this.totalYearlyCost / this.paychecksPerYear;
  }

  private clearCosts() {
    this.employeeDiscountApplied = false;
    this.dependentDiscountsApplied = 0;
    this.employeeCost = this.employeeBaseCost;
    this.dependentCost = 0;
    this.totalYearlyCost = 0;
    this.totalCostPerPayPeriod = 0;
  }
}