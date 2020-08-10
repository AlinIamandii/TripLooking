import { Injectable } from '@angular/core';
import { BehaviorSubject, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  usernameSubject: BehaviorSubject<string>;

  constructor() {
    this.usernameSubject = new BehaviorSubject<string>('');

    const username = localStorage.getItem('username');
    if (username) {
      this.usernameSubject.next(username);
    }
  }

  setUsername(username: string): void {
    localStorage.setItem('username', username);
    this.usernameSubject.next(username);
  }
}
