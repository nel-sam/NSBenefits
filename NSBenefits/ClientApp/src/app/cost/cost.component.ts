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

  constructor(private employeeService: EmployeeService) {
    this.employees$ = employeeService.getAll();
  }
}