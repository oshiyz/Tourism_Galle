import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../../services/auth.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [CommonModule, FormsModule],
  template: `
    <div class="container">
      <h2>Register</h2>
      <form (submit)="register()">
        <input type="text" placeholder="Full Name" [(ngModel)]="user.fullName" required />
        <input type="email" placeholder="Email" [(ngModel)]="user.email" required />
        <input type="password" placeholder="Password" [(ngModel)]="user.password" required />
        <button type="submit">Register</button>
      </form>
    </div>
  `
})
export class RegisterComponent {
  user = { fullName: '', email: '', password: '' };

  constructor(private authService: AuthService, private router: Router) {}

  register() {
    this.authService.register(this.user).subscribe(
      () => {
        alert('Registration successful!');
        this.router.navigate(['/login']);
      },
      (error) => alert(error.error)
    );
  }
}
