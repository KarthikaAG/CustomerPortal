import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'https://localhost:7258/api/Users';

  constructor(private http: HttpClient) { }

  register(user: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/register`, user);
  }

  login(credentials: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/login`, credentials).pipe(
      tap((response: any) => {
        localStorage.setItem('token', response.token);
        localStorage.setItem('fullName', response.fullName); 
      }),
      catchError(error => {
        return of(error);
      })
    );
  }

  userExists(username: string): Observable<any> {
    return this.http.get(`${this.apiUrl}/exists/${username}`);
  }

  getUserProfile(): Observable<any> {
    return this.http.get(`${this.apiUrl}/profile`);
  }

  getFullName(): string {
    return localStorage.getItem('fullName') || '';
  }

  logout(): void {
    localStorage.removeItem('token');
    localStorage.removeItem('fullName');
    window.location.href = '/sign-in';
  }
}

