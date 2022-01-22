import { Component, OnInit, ElementRef } from '@angular/core';
import { ROUTES } from '../sidebar/sidebar.component';
import {Location, LocationStrategy, PathLocationStrategy} from '@angular/common';
import { Router } from '@angular/router';
import Chart from 'chart.js';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
    private listTitles: any[];
    location: Location;
      mobile_menu_visible: any = 0;
    private toggleButton: any;
    private sidebarVisible: boolean;

    public isCollapsed = true;

    constructor(location: Location,  private element: ElementRef, private router: Router) {
      this.location = location;
          this.sidebarVisible = false;
    }

    ngOnInit(){
      this.listTitles = [
      {path: '/teacher/list', title: 'Theacher'},
      {path: '/teacher/create', title: 'Theacher'},
      {path: '/teacher/detail', title: 'Theacher'},

      {path: '/student/list', title: 'Student'},
      {path: '/student/create', title: 'Student'},
      {path: '/student/detail', title: 'Student'},
    
      {path: '/course/list', title: 'Course'},
      {path: '/course/create', title: 'Course'},
      {path: '/course/detail', title: 'Course'},
    
      {path: '/subject/list', title: 'Subject'},
      {path: '/subject/create', title: 'Subject'},
      {path: '/subject/detail', title: 'Subject'}
    ]
    }

    getTitle(){
      var titlee = this.location.prepareExternalUrl(this.location.path());
      if(titlee.charAt(0) === '#'){
          titlee = titlee.slice( 2 );
      }
      for(var item = 0; item < this.listTitles.length; item++){
          if(this.listTitles[item].path === titlee){
              return this.listTitles[item].title;
          }
      }
      return '';
    }
}
