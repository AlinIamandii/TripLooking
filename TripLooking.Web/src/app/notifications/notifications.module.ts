import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { NotificationsRoutingModule } from './notifications-routing.module';
import { NotificationsComponent } from './notifications/notifications.component';

@NgModule({
  declarations: [NotificationsComponent],
  imports: [CommonModule, NotificationsRoutingModule],
  exports: [NotificationsComponent],
})
export class NotificationsModule {}
