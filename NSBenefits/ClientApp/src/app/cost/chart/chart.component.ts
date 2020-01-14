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

  ngOnChanges() {
    this.costPercentageOfPay = ((this.totalCostPerPayPeriod / this.salary) * 100);
  }
}
