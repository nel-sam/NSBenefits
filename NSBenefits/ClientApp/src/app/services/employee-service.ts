import { Injectable, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Employee, CostAnalysis } from "../interfaces/interfaces";
import { Observable } from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  private baseUrl: string;
  private employeeBaseCost: number = 1000;
  private paychecksPerYear: number = 26;
  private discountPercentage: number = 0.1;

  public dependentBaseCost: number = 500;
  constructor(private httpClient: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  public getAll(): Observable<Employee[]> {
    return this.httpClient.get<Employee[]>(this.baseUrl + 'employee');
  }

  public create(employee: Employee): Observable<any> {
    return this.httpClient.post(this.baseUrl + 'employee', employee);
  }

  public calculateCost(employee: Employee): CostAnalysis {
    let employeeCost = this.employeeBaseCost;
    let dependentCost = 0;
    let dependentDiscountsApplied = 0;
    let employeeDiscountApplied = false;

    if (employee.firstName[0].toUpperCase() === 'A') {
      employeeCost = this.employeeBaseCost - (this.employeeBaseCost * this.discountPercentage);
      employeeDiscountApplied = true;
    }

    for (let dependent of employee.dependents) {
      dependentCost += this.dependentBaseCost;

      if (dependent.firstName[0].toUpperCase() === 'A') {
        dependentCost -= this.dependentBaseCost * this.discountPercentage;
        dependent.discountApplies = true;
        dependentDiscountsApplied++;
      }
    }

    const totalYearlyCost = employeeCost + dependentCost;
    const totalCostPerPayPeriod = totalYearlyCost / this.paychecksPerYear;

    const result = {
      employeeCost,
      employeeDiscountApplied,
      totalYearlyCost,
      totalCostPerPayPeriod,
      dependentCost,
      dependentDiscountsApplied,
    } as CostAnalysis;

    return result;
  }
}
