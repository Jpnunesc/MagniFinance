import { Routes } from '@angular/router';
import { AuthGuard } from '../components/auth/auth.guard';
import { SubjectFormComponent } from './subject/subject-form/subject-form.component';
import { SubjectListComponent } from './subject/subject-list/subject-list.component';
import { TeacherFormComponent } from './teacher/teacher-form/teacher-form.component';
import { TeacherListComponent } from './teacher/teacher-list/teacher-list.component';

export const LayoutRoutes: Routes = [
    { path: 'teacher/create', canActivate: [AuthGuard], component: TeacherFormComponent },
    { path: 'teacher/edit/:id', canActivate: [AuthGuard], component: TeacherFormComponent },
    { path: 'teacher/detail/:id', data: {detail:true}, canActivate: [AuthGuard], component: TeacherFormComponent },
    { path: 'teacher/list', canActivate: [AuthGuard], component: TeacherListComponent },

    { path: 'course/create', canActivate: [AuthGuard], component: TeacherFormComponent },
    { path: 'course/edit/:id', canActivate: [AuthGuard], component: TeacherFormComponent },
    { path: 'course/detail/:id', data: {detail:true}, canActivate: [AuthGuard], component: TeacherFormComponent },
    { path: 'course/list', canActivate: [AuthGuard], component: TeacherListComponent },

    { path: 'student/create', canActivate: [AuthGuard], component: TeacherFormComponent },
    { path: 'student/edit/:id', canActivate: [AuthGuard], component: TeacherFormComponent },
    { path: 'student/detail/:id', data: {detail:true}, canActivate: [AuthGuard], component: TeacherFormComponent },
    { path: 'student/list', canActivate: [AuthGuard], component: TeacherListComponent },

    { path: 'subject/create', canActivate: [AuthGuard], component: SubjectFormComponent },
    { path: 'subject/edit/:id', canActivate: [AuthGuard], component: SubjectFormComponent },
    { path: 'subject/detail/:id', data: {detail:true}, canActivate: [AuthGuard], component: SubjectFormComponent },
    { path: 'subject/list', canActivate: [AuthGuard], component: SubjectListComponent },


];
