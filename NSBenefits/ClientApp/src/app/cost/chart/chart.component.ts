import { Component, Input, OnChanges } from '@angular/core';

@Component({
  selector: 'app-chart',
  templateUrl: './chart.component.html',
  styleUrls: ['./chart.component.scss']
})
export class ChartComponent implements OnChanges {
  @Input() salary: number;
  @Input() totalCostPerPayPeriod: number;
  public costPercentageOfPay: number = 0;
  public costBarWidth: string;

  ngOnChanges() {
    this.costPercentageOfPay = this.getCostPercentage(this.totalCostPerPayPeriod, this.salary);
    this.costBarWidth = this.getCostBarWidth(this.costPercentageOfPay);
    }

    getCostPercentage(totalCostPerPayPeriod: number, salary: number): number {
      return (totalCostPerPayPeriod / salary) * 100;
    }

    getCostBarWidth(costPercentageOfPay: number): string {
      return `${costPercentageOfPay * 10}px`
    }
}
