export interface AppState {
  employees: Employee[];
}

export interface Person {
  firstName: string;
  lastName: string;
}

export interface Employee extends Person {
  salary: number;
  dependents: Dependent[];
}

export interface Dependent extends Person {
  discountApplies: boolean;
}