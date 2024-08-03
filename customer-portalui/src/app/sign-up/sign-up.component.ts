import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { tap, catchError } from 'rxjs/operators';
import { of } from 'rxjs';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignupComponent {
  username: string = '';
  fullName: string = '';
  email: string = '';
  password: string = '';
  confirmPassword: string = '';

  constructor(private authService: AuthService, private router: Router) { }

  signup() {
    const user = {
      username: this.username,
      fullName: this.fullName,
      email: this.email,
      password: this.password,
      confirmPassword: this.confirmPassword
    };

    this.authService.register(user).pipe(
      tap(response => {
        alert('Registration successful!');
        this.router.navigate(['/sign-in']);
      }),
      catchError(error => {
        alert('Registration failed: ' + error.error);
        return of(error);
      })
    ).subscribe();
  }
}
