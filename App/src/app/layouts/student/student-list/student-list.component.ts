import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { StudentService } from '../student.service';

@Component({
  selector: 'app-student-list',
  templateUrl: './student-list.component.html',
  styleUrls: ['./student-list.component.css']
})
export class StudentListComponent implements OnInit {
  data = [];
  opemModal = false;
  idItemDelete = 0;
  constructor(private studentService: StudentService,
              private toastr: ToastrService,) { }

  ngOnInit(): void {
    this.getTeacher();
  }
getTeacher() {
  this.studentService.httpGet().subscribe((element) => {
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
    this.studentService.httpDelete(this.idItemDelete).subscribe(data => {
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
