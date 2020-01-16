import { Component, Input } from '@angular/core';
import { Employee, CostAnalysis } from 'src/app/interfaces/interfaces';

@Component({
  selector: 'app-breakdown',
  templateUrl: './breakdown.component.html',
  styleUrls: ['./breakdown.component.scss']
})
export class BreakdownComponent {
  @Input() costAnalysis: CostAnalysis;
  @Input() selectedEmployee: Employee;
}
