import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Policy } from '../models/policy';

@Injectable({
  providedIn: 'root'
})
export class PolicyService {
  private apiUrl = 'http://localhost:7258/api/policy';  

  constructor(private http: HttpClient) {}

  getPolicyDetails(): Observable<Policy> {
    return this.http.get<Policy>(`${this.apiUrl}/details`);
  }

  getUserPolicies(): Observable<any> {
    return this.http.get(`${this.apiUrl}/user`);
  }

  addPolicy(policyNumber: string, chassisNumber: string): Observable<any> {
    return this.http.post(`${this.apiUrl}/add`, { policyNumber, chassisNumber });
  }

  removePolicy(policyNumber: string): Observable<any> {
    return this.http.delete(`${this.apiUrl}/remove/${policyNumber}`);
  }
}
