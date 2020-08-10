import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AuthGuard } from './shared/guards/auth.guard';
import { TripDetailsComponent } from './trip/trip-details/trip-details.component';
import { TripListComponent } from './trip/trip-list/trip-list.component';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    redirectTo: 'authentication',
  },
  {
    path: 'authentication',
    loadChildren: () => import('./authentication/authentication.module').then((m) => m.AuthenticationModule),
  },
  {
    path: 'list',
    component: TripListComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'create-trip',
    component: TripDetailsComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'notifications',
    loadChildren: () => import('./notifications/notifications.module').then((m) => m.NotificationsModule),
    canActivate: [AuthGuard]
  },
  {
    path: 'dashboard',
    loadChildren: () => import('./dashboard/dashboard.module').then((m) => m.DashboardModule),
    canActivate: [AuthGuard]
  },
  {
    path: 'trip',
    loadChildren: () => import('./trip/trip.module').then((m) => m.TripModule),
    canActivate: [AuthGuard]
  },
  {
    path: '**',
    redirectTo: 'authentication',
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
