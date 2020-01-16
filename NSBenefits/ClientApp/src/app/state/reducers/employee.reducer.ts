import { Action } from '@ngrx/store';
import { Employee } from './../../interfaces/interfaces';
import * as EmployeeActions from './../actions/employee.actions';

export function employeeReducer(
  state: Employee[] = [],
  action: EmployeeActions.Actions) {
    switch(action.type) {
      case EmployeeActions.ADD_EMPLOYEE:
          return [...state, action.payload];
      case EmployeeActions.LOAD_EMPLOYEES:
          return [...action.payload];
      default:
        return state;
    }
}

