import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { LoginService } from './login/login.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private modalService: LoginService, private router: Router) {}

  canActivate(): boolean {
    const isAuthenticated = this.checkIfUserIsAuthenticated();

    if (!isAuthenticated) {
      this.router.navigate(['/']); // Redirect to home 
    }

    return isAuthenticated;
  }

  private checkIfUserIsAuthenticated(): boolean {
    // Add your authentication logic here
    // Return true if authenticated, false otherwise
    return false;
  }
}