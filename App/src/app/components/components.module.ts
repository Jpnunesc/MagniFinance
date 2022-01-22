import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { FooterComponent } from './footer/footer.component';
import { NavbarComponent } from './navbar/navbar.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { FieldErrorsComponent } from './field-errors/field-errors.component';
import { HistoricModalComponent } from './modal/historic-modal/historic-modal.component';
import { ModalComponent } from './modal/modal/modal.component';



@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    NgbModule,


  ],
  declarations: [
    FooterComponent,
    NavbarComponent,
    SidebarComponent,
    FieldErrorsComponent,
    HistoricModalComponent,
    ModalComponent

  ],
  exports: [
    FooterComponent,
    NavbarComponent,
    SidebarComponent,
    FieldErrorsComponent,
    HistoricModalComponent,
    ModalComponent

  ]
})
export class ComponentsModule { }
