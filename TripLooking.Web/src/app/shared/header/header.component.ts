import { ChangeDetectorRef, Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/authentication/services/authentication.service';

import { UserService } from '../services';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
})
export class HeaderComponent {
  username: string = '';
  constructor(
    public readonly userService: UserService,
    private readonly authenticationService: AuthenticationService,
    private readonly router: Router
  ) {

    this.userService.usernameSubject.subscribe(data => {
      this.username = data;
    })
  }

  public logout(): void {
    this.authenticationService.logout();
    this.router.navigate(['/authentication']);
  }
}
