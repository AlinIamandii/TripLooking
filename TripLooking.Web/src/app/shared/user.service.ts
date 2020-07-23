import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  public email: Subject<string>;

  constructor() {
    this.email = new Subject<string>();
  }
}
