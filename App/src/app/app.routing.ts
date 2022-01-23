import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { Routes, RouterModule } from '@angular/router';
import { AdminLayoutComponent } from './layouts/admin-layout/admin-layout.component';
import { AuthGuard } from './components/auth/auth.guard';
import { LoginComponent } from './user/login/login.component';

const routes: Routes = [
  {
    path: 'login',
    component: LoginComponent,
    data:
    {
      titulo: 'Login',
    },
  },
  {
    path: '',
    component: LoginComponent,
    data:
    {
      titulo: 'Login',
    },
  },

  {
    path: '',
    canActivate: [AuthGuard], component: AdminLayoutComponent,
    children:
      [
        {
          path: '',
          loadChildren: './layouts/layout.module#LayoutModule'
        }
      ]
  },
  {
    path: '**',
    canActivate: [AuthGuard],
    redirectTo: 'teacher/list'
  }
];

@NgModule({
  imports: [
    BrowserModule,
    RouterModule.forRoot(routes)
  ],
  exports: [],
})
export class AppRoutingModule { }
