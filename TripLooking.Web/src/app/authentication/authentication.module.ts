import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { AuthenticationRoutingModule } from './authentication-routing.module';
import { AuthenticationComponent } from './authentication/authentication.component';
import { SubmitButtonComponent } from './submit-button/submit-button.component';

@NgModule({
  declarations: [AuthenticationComponent, SubmitButtonComponent],
  imports: [
    CommonModule,
    AuthenticationRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    RouterModule,
    FormsModule,
  ],
  exports: [AuthenticationComponent],
})
export class AuthenticationModule {}
