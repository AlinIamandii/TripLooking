import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  public username: Subject<string>;

  constructor() {
    this.username = new Subject<string>();
  }
}
