import { Component } from '@angular/core';
import { AuthService } from '../services/auth.service'; // Adjust the path based on your project structure
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-login',
  imports: [FormsModule, CommonModule],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  credentials = { email: '', password: '' }; // Assuming email & password for login

  constructor(private authService: AuthService, private router: Router) {}

  login() {
    this.authService.login(this.credentials);
    this.router.navigate(['/contact']); // Redirect to contacts page after login
  }
}
