import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthenticationService {
  endpoint: string = 'http://trip-looking.ashbell-platform.com/api/v1/auth';

  constructor(
    private readonly httpClient: HttpClient,
    private readonly jwtHelperService: JwtHelperService) { }

  isAuthenticated(): boolean {
    const token = localStorage.getItem('userToken');

    if (token) {
      return !this.jwtHelperService.isTokenExpired(token);
    }
    return false;
  }

  login(data: unknown): Observable<unknown> {
    return this.httpClient.post(`${this.endpoint}/login`, data);
  }

  logout(): void {
    localStorage.removeItem('userToken');
  }

  register(data: unknown): Observable<unknown> {
    return this.httpClient.post(`${this.endpoint}/register`, data);
  }
}
