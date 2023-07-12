import { Component, Inject } from '@angular/core';
import { LoginService } from './login.service';
import { HttpClient } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';

@Component({
  selector: 'app-login-form',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
    constructor(private loginService: LoginService, private http: HttpClient, @Inject('BASE_URL') baseUrl: string) 
    {
        this.apiBaseUrl = baseUrl;
    }
    apiBaseUrl: string = "";
    username = "";
    password = "";
    isOpen: boolean = false;

    onSubmit() 
    {
        const payload = 
        {
          username: this.username,
          password: this.password
        };
    
        this.http.post(this.apiBaseUrl + 'login', payload)
        .pipe
        (
          catchError((error) => 
          {
            // Handle login error
            console.error('Login failed', error);
            // Display an error message or perform any necessary actions
            return throwError(() => new Error(error))
          })
        )
        .subscribe((response) => 
        {
          // Handle successful login response
          console.log('Login successful', response);
          // Perform any necessary actions, such as storing tokens or redirecting
        });
    }
}