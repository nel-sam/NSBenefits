import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { Employee } from '../interfaces/interfaces';
import { EmployeeService } from '../services/employee-service';

@Component({
  selector: 'app-cost',
  templateUrl: './cost.component.html',
  styleUrls: [ './cost.component.scss' ]
})
export class CostComponent {
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
  public costPercentageOfPay: number;

  constructor(private employeeService: EmployeeService) {
    this.employees$ = this.employeeService.getAll();
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
        this.dependentDiscountsApplied++;
      }
    }

    this.totalYearlyCost = this.employeeCost + this.dependentCost;
    this.totalCostPerPayPeriod = this.totalYearlyCost / this.paychecksPerYear;
    this.costPercentageOfPay = ((this.totalCostPerPayPeriod / employee.salary) * 100);
  }

  private clearCosts() {
    this.employeeDiscountApplied = false;
    this.dependentDiscountsApplied = 0;
    this.employeeCost = this.employeeBaseCost;
    this.dependentCost = 0;
    this.totalYearlyCost = 0;
    this.totalCostPerPayPeriod = 0;
    this.costPercentageOfPay = 0;
  }
}