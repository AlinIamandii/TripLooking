import { Component, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';

import { LoginModel } from '../models/login.model';
import { RegisterModel } from '../models/register.model';
import { AuthenticationService } from '../services/authentication.service';
import { UserService } from 'src/app/shared/user.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-authentication',
  templateUrl: './authentication.component.html',
  styleUrls: ['./authentication.component.scss'],
})
export class AuthenticationComponent implements OnDestroy {
  private subscription: Subscription;
  public isSetRegistered: boolean = false;
  public isAdmin: boolean = false;
  public email: string = null;
  public password: string = null;
  public fullName: string = null;

  public form: FormGroup;
  public data = [
    {
      fruit: 'Orange',
      color: 'Orange',
    },
    {
      fruit: 'Strawberry',
      color: 'Red',
    },
    {
      fruit: 'Pineapple',
      color: 'Yellow',
    },
  ];

  public config = {
    email: 'cutarescu@gmail.com',
    password: 'parola',
    fullName: ' gigi',
  };

  public defaultEmail: string = 'default@domain.net';
  // in constructor apar serviciile pe care le injectam la noi in aplicatie
  constructor(
    private readonly authenticationService: AuthenticationService,
    private readonly router: Router,
    private readonly userService: UserService
  ) {
    this.subscription = new Subscription();
    this.form = new FormGroup({
      email: new FormControl(this.config.email, [Validators.maxLength(5)]),
      password: new FormControl(this.config.password, [Validators.required]),
      fullName: new FormControl(this.config.fullName, []),
    });
  }

  public ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  public setRegister(): void {
    this.isSetRegistered = !this.isSetRegistered;
  }

  public setAdmin(): void {
    this.isAdmin = !this.isAdmin;
  }

  public authenticate(): void {
    if (this.isSetRegistered) {
      // initializam variabila cu modelul stabilit pentru register
      // const registerModel: RegisterModel = {
      //   email: this.emailControl.value,
      //   password: this.passwordControl.value,
      //   fullName: this.fullNameControl.value,
      // };
      // this.subscription.add(
      //   // aici apelam metoda register din serviciu, pentru a face requestul catre back end
      //   this.authenticationService.register(registerModel).subscribe(() => {
      //     this.router.navigate(['dashboard']);
      //     this.userService.email.next(registerModel.email);
      //   })
      // );
    } else {
      // initializam variabila cu modelul stabilit pentru login
      const loginModel: LoginModel = {
        email: this.email,
        password: this.password,
      };

      this.subscription.add(
        // aici apelam metoda login din serviciu, pentru a face requestul catre back end
        this.authenticationService.login(loginModel).subscribe(() => {
          this.router.navigate(['dashboard']);
          this.userService.email.next(loginModel.email);
        })
      );
    }
  }

  public get emailControl(): FormControl {
    return this.form.controls.email as FormControl;
  }

  public get isFormValid(): boolean {
    return this.form.valid;
  }

  public setValue(): void {
    this.emailControl.setValue(this.defaultEmail);
  }
}
