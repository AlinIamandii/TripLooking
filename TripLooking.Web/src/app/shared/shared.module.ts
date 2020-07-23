import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';

import { HeaderComponent } from './header/header.component';
import { TileComponent } from './tile/tile.component';
import { SubmitButtonComponent } from './submit-button/submit-button.component';

@NgModule({
  declarations: [TileComponent, HeaderComponent, SubmitButtonComponent],
  imports: [CommonModule, MatIconModule],
  exports: [TileComponent, HeaderComponent, SubmitButtonComponent],
})
export class SharedModule {}
