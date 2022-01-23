import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { SubjectService } from '../subject.service';

@Component({
  selector: 'app-subject-list',
  templateUrl: './subject-list.component.html',
  styleUrls: ['./subject-list.component.css']
})
export class SubjectListComponent implements OnInit {

  data = [];
  opemModal = false;
  idItemDelete = 0;
  constructor(private subjectService: SubjectService,
              private toastr: ToastrService,) { }

  ngOnInit(): void {
    this.getTeacher();
  }
getTeacher() {
  this.subjectService.httpGet().subscribe((element) => {
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
    this.subjectService.httpDelete(this.idItemDelete).subscribe(data => {
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