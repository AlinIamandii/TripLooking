import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { SharedModule } from '../shared/shared.module';

import { TripDetailsComponent } from './trip-details/trip-details.component';
import { TripListComponent } from './trip-list/trip-list.component';
import { TripRoutingModule } from './trip-routing.module';
import { CreateComponent } from './create/create.component';

@NgModule({
  declarations: [TripDetailsComponent, TripListComponent, CreateComponent],
  imports: [
    CommonModule,
    TripRoutingModule,
    FormsModule,
    SharedModule,
    ReactiveFormsModule,
  ],
  exports: [TripDetailsComponent, TripListComponent],
})
export class TripModule {}
