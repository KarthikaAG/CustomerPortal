import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { tap, catchError } from 'rxjs/operators';
import { of } from 'rxjs';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SigninComponent {
  username: string = '';
  password: string = '';

  constructor(private authService: AuthService, private router: Router) { }

  signin() {
    const credentials = {
      username: this.username,
      password: this.password
    };

    this.authService.login(credentials).pipe(
      tap(response => {
        alert('Login successful!');
        this.router.navigate(['/my-policies']);
      }),
      catchError(error => {
        alert('Login failed: ' + error.error);
        return of(error);
      })
    ).subscribe();
  }
}
