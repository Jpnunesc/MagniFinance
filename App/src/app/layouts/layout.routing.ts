import { Routes } from '@angular/router';
import { AuthGuard } from '../components/auth/auth.guard';
import { CourseFormComponent } from './course/course-form/course-form.component';
import { CourseListComponent } from './course/course-list/course-list.component';
import { GradeFormComponent } from './grade/grade-form/grade-form.component';
import { StudentFormComponent } from './student/student-form/student-form.component';
import { StudentListComponent } from './student/student-list/student-list.component';
import { SubjectFormComponent } from './subject/subject-form/subject-form.component';
import { SubjectListComponent } from './subject/subject-list/subject-list.component';
import { TeacherFormComponent } from './teacher/teacher-form/teacher-form.component';
import { TeacherListComponent } from './teacher/teacher-list/teacher-list.component';

export const LayoutRoutes: Routes = [
    
    { path: 'grade/create/:idCourse/:idStudent', canActivate: [AuthGuard], component: GradeFormComponent },

    { path: 'teacher/create', canActivate: [AuthGuard], component: TeacherFormComponent },
    { path: 'teacher/edit/:id', canActivate: [AuthGuard], component: TeacherFormComponent },
    { path: 'teacher/detail/:id', data: {detail:true}, canActivate: [AuthGuard], component: TeacherFormComponent },
    { path: 'teacher/list', canActivate: [AuthGuard], component: TeacherListComponent },

    { path: 'course/create', canActivate: [AuthGuard], component: CourseFormComponent },
    { path: 'course/edit/:id', canActivate: [AuthGuard], component: CourseFormComponent },
    { path: 'course/detail/:id', data: {detail:true}, canActivate: [AuthGuard], component: CourseFormComponent },
    { path: 'course/list', canActivate: [AuthGuard], component: CourseListComponent },

    { path: 'student/create', canActivate: [AuthGuard], component: StudentFormComponent },
    { path: 'student/edit/:id', canActivate: [AuthGuard], component: StudentFormComponent },
    { path: 'student/detail/:id', data: {detail:true}, canActivate: [AuthGuard], component: StudentFormComponent },
    { path: 'student/list', canActivate: [AuthGuard], component: StudentListComponent },

    { path: 'subject/create', canActivate: [AuthGuard], component: SubjectFormComponent },
    { path: 'subject/edit/:id', canActivate: [AuthGuard], component: SubjectFormComponent },
    { path: 'subject/detail/:id', data: {detail:true}, canActivate: [AuthGuard], component: SubjectFormComponent },
    { path: 'subject/list', canActivate: [AuthGuard], component: SubjectListComponent },


];
