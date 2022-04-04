import { NgModule } from '@angular/core';
import { NgbCollapseModule, NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap';
import { PageModule } from '@abp/ng.components/page';
import { SharedModule } from '../shared/shared.module';
import { CharacterRoutingModule } from './character-routing.module';
import { CharacterComponent } from './character.component';

@NgModule({
  declarations: [CharacterComponent],
  imports: [CharacterRoutingModule, SharedModule, NgbCollapseModule, NgbDatepickerModule, PageModule],
})
export class CharacterModule {}
