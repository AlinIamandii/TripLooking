import { Component, OnInit } from '@angular/core';
import { UserService } from '../user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
})
export class HeaderComponent implements OnInit {
  public username: string;
  constructor(
    public readonly userService: UserService,
    private readonly router: Router
  ) {}

  ngOnInit() {
    this.username = '';
  }

  logout(): void {
    this.userService.email.next(null);
    this.router.navigate(['authentication']);
  }
}
