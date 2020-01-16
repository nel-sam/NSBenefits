import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Employee, AppState, CostAnalysis } from '../../interfaces/interfaces';
import { EmployeeService } from '../../services/employee-service';
import { Store } from '@ngrx/store';
import * as EmployeeActions from '../../state/actions/employee.actions'
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'app-report-review',
  templateUrl: './report-review.component.html',
  styleUrls: [ './report-review.component.scss' ]
})
export class ReportReviewComponent implements OnInit {
  public employees$: Observable<Employee[]>;
  public selectedEmployee: Employee;
  public costAnalysis: CostAnalysis;

  constructor(
    private titleService: Title,
    private store: Store<AppState>,
    private employeeService: EmployeeService) {
    this.employees$ = this.store.select('employees');
  }

  ngOnInit() {
    this.titleService.setTitle('Review Reports');

    this.employeeService.getAll()
      .subscribe(result => {
          this.store.dispatch(new EmployeeActions.LoadAllEmployees(result))
      }, error => {
        alert('Error occurred ' + error);
      });
  }

  public calculateCost(employee: Employee) {
    this.costAnalysis = this.employeeService.calculateCost(employee);
  }
}