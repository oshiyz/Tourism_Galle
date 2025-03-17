import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../../services/auth.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule],
  template: `
    <div class="container">
      <h2>Login</h2>
      <form (submit)="login()">
        <input type="email" placeholder="Email" [(ngModel)]="credentials.email" required />
        <input type="password" placeholder="Password" [(ngModel)]="credentials.password" required />
        <button type="submit">Login</button>
      </form>
    </div>
  `
})
export class LoginComponent {
  credentials = { email: '', password: '' };

  constructor(private authService: AuthService, private router: Router) {}

  login() {
    this.authService.login(this.credentials).subscribe(
      (res) => {
        alert('Login successful!');
        localStorage.setItem('user', JSON.stringify(res));
        this.router.navigate(['/']);
      },
      () => alert('Invalid credentials')
    );
  }
}
