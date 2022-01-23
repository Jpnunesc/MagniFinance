import { Component, OnInit } from '@angular/core';

declare interface RouteInfo {
    path: string;
    title: string;
    icon: string;
    class: string;
}
export const ROUTES: RouteInfo[] = [
    { path: '/teacher/list', title: 'Theacher',  icon:'users_single-02', class: '' },
    { path: '/student/list', title: 'Student',  icon:'education_hat', class: '' },
    { path: '/subject/list', title: 'Subject',  icon:'education_agenda-bookmark', class: '' },
    { path: '/course/list', title: 'Course',  icon:'education_paper', class: '' },
    { path: '/login', title: 'Sair',  icon:'arrows-1_share-66', class: '' },

];

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {
  menuItems: any[];

  constructor() { }

  ngOnInit() {
    this.menuItems = ROUTES.filter(menuItem => menuItem);
  }
  isMobileMenu() {
      if ( window.innerWidth > 991) {
          return false;
      }
      return true;
  };
}
