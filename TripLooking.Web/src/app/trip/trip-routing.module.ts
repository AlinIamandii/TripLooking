import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { TripDetailsComponent } from './trip-details/trip-details.component';
import { TripListComponent } from './trip-list/trip-list.component';


const routes: Routes = [
  {
    path: 'list',
    pathMatch: 'full',
    component: TripListComponent,
  },
  {
    path: 'details/:id',
    pathMatch: 'full',
    component: TripDetailsComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class TripRoutingModule { }
