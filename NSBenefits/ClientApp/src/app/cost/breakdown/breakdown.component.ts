import { Component, Input } from '@angular/core';
import { Employee } from 'src/app/interfaces/interfaces';

@Component({
  selector: 'app-breakdown',
  templateUrl: './breakdown.component.html',
  styleUrls: ['./breakdown.component.scss']
})
export class BreakdownComponent {
  @Input() employeeDiscountApplied: boolean;
  @Input() employeeCost: number;
  @Input() dependentCost: number;
  @Input() totalCostPerPayPeriod: number;
  @Input() totalYearlyCost: number;
  @Input() selectedEmployee: Employee;
}
