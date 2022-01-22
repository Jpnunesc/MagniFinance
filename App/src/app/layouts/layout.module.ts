import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { LayoutRoutes } from './layout.routing';
import { ChartsModule } from 'ng2-charts';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { LoginComponent } from '../usuario/login/login.component';
import { AdminLayoutComponent } from './admin-layout/admin-layout.component';
import { UsuarioComponent } from '../usuario/usuario.component';
import { ComponentsModule } from '../components/components.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TeacherFormComponent } from './teacher/teacher-form/teacher-form.component';
import { TeacherListComponent } from './teacher/teacher-list/teacher-list.component';
import { SubjectListComponent } from './subject/subject-list/subject-list.component';
import { SubjectFormComponent } from './subject/subject-form/subject-form.component';


@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(LayoutRoutes),
    ChartsModule,
    NgbModule,
    ComponentsModule,
    ReactiveFormsModule,
    FormsModule
  ],
  declarations: [
    UsuarioComponent,
    LoginComponent,
    AdminLayoutComponent,
    TeacherFormComponent,
    TeacherListComponent,
    SubjectListComponent,
    SubjectFormComponent
  ]
})

export class LayoutModule {}
