import { Injectable, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Employee } from "../interfaces/interfaces";
import { Observable } from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  private baseUrl: string;

  constructor(private httpClient: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  public getAll(): Observable<Employee[]> {
    return this.httpClient.get<Employee[]>(this.baseUrl + 'employee');
  }
}
