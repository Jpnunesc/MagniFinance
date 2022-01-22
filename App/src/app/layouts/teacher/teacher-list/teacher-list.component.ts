import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { element } from 'protractor';
import { TeacherService } from '../teacher.service';

@Component({
  selector: 'app-teacher-list',
  templateUrl: './teacher-list.component.html',
  styleUrls: ['./teacher-list.component.css']
})
export class TeacherListComponent implements OnInit {
  data = [];
  opemModal = false;
  idItemDelete = 0;
  constructor(private teacherService: TeacherService,
              private toastr: ToastrService,) { }

  ngOnInit(): void {
    this.getTeacher();
  }
getTeacher() {
  this.teacherService.httpGet().subscribe((element) => {
    if(element && element.status) {
      this.data = element.object
    } else {
      this.data = [];
    }
  }), (error => {
      console.log(error);
  })
}
deleteItem() {
  if(this.idItemDelete) {
    this.teacherService.httpDelete(this.idItemDelete).subscribe(data => {
      this.opemModal = false;
      if(data && data.status) {
        this.toastr.success(data.message);
        this.getTeacher();
      } else {
        this.toastr.error(data.message);
      }
    }), (error) => {
      this.toastr.error('Internal error!');
      console.log(error);
    }
  }
}
}
