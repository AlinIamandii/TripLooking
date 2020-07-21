import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';

import { HeaderComponent } from './header/header.component';
import { TileComponent } from './tile/tile.component';

@NgModule({
  declarations: [TileComponent, HeaderComponent],
  imports: [CommonModule, MatIconModule],
  exports: [TileComponent, HeaderComponent],
})
export class SharedModule {}
