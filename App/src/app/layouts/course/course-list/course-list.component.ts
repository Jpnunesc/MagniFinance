import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { CourseService } from '../course.service';

@Component({
  selector: 'app-course-list',
  templateUrl: './course-list.component.html',
  styleUrls: ['./course-list.component.css']
})
export class CourseListComponent implements OnInit {
  data = [];
  opemModal = false;
  idItemDelete = 0;
  constructor(private courseService: CourseService,
              private toastr: ToastrService,) { }

  ngOnInit(): void {
    this.getTeacher();
  }
getTeacher() {
  this.courseService.httpGet().subscribe((element) => {
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
    this.courseService.httpDelete(this.idItemDelete).subscribe(data => {
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
