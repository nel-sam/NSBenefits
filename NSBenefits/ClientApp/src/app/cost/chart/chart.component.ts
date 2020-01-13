import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-chart',
  templateUrl: './chart.component.html',
  styleUrls: ['./chart.component.scss']
})
export class ChartComponent implements OnInit {
  @Input() salary: number;
  @Input() totalCostPerPayPeriod: number;
  public costPercentageOfPay: number = 0

  ngOnInit() {
    this.costPercentageOfPay = ((this.totalCostPerPayPeriod / this.salary) * 100);
  }
}
