import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CourseService } from '../course.service';

@Component({
  selector: 'app-course-form',
  templateUrl: './course-form.component.html',
  styleUrls: ['./course-form.component.css']
})
export class CourseFormComponent implements OnInit {
  form: FormGroup;
  disabled = false;
  retunrUrl = '../list'
  listSubject = [];
  constructor(private fb: FormBuilder,
    private toastr: ToastrService,
    private courseService: CourseService,
    public activeRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.form = this.fb.group({
      id:[],
      status:[],
      name: ['', [Validators.required]]
    });
    const id = this.activeRoute.snapshot.params.id;
    if (id) {
      this.disabled = this.activeRoute.snapshot.data.detail ? true : false;
      this.retunrUrl = '../../list'
      this.getById(id);
    }
  }
  getById(id) {
    this.courseService.httpGetId(id).subscribe(data => {
      if (data && data.status) {
        this.form.patchValue(data.object);
      }
    }), error => {
      console.log(error);
    };
    ;
  }
  save() {
    if (!this.form.valid) return;
    if(this.activeRoute.snapshot.params.id) {
      this.courseService.httpPut(this.form.value).subscribe((data) => {
        this.form.reset();
        if (data && data.status) {
          this.toastr.success(data.message);
        } else {
          this.toastr.error(data.message);
        }
      }), (error) => {
        this.toastr.error('Internal error!');
        console.log(error);
      }
    } else {
      this.courseService.httpPost(this.form.value).subscribe((data) => {
        this.form.reset();
        if (data && data.status) {
          this.toastr.success(data.message);
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
