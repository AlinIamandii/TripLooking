import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
// initializare string cu url
const endpoint = 'http://trip-looking.ashbell-platform.com/api/v1/auth';

@Injectable({
  providedIn: 'root',
})
export class AuthenticationService {
  constructor(private readonly httpClient: HttpClient) {}
// metoda de register pe care o apelam cand dorim sa facem requestul
public register(data: unknown): Observable<unknown> {
  return this.httpClient.post(`${endpoint}/register`, data);
}

// metoda de login pe care o apelam cand dorim sa facem requestul
  public login(data: unknown): Observable<unknown> {
    return this.httpClient.post(`${endpoint}/login`, data);
  }
}
