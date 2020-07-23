import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AuthenticationComponent } from './authentication/authentication.component';
import { AuthenticationService } from './services/authentication.service';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    component: AuthenticationComponent,
  },
];
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: [AuthenticationService],
})
export class AuthenticationRoutingModule {}
