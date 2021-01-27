import { HttpClient
  , HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Employee } from 'src/app/models/employee';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(public http: HttpClient) { }


  getAllEmployees():  Observable<Employee[]> {
		return this.http.get<Employee[]>(
			environment.apiUrl + '/Employee');
	}

  	getEmployeeByID(id: number): Observable<Employee> {
	    	return this.http.get<Employee>(
			environment.apiUrl + '/Employee/' + id)
  	}
}
