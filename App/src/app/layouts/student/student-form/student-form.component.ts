import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CourseService } from '../../course/course.service';
import { StudentService } from '../student.service';

@Component({
  selector: 'app-student-form',
  templateUrl: './student-form.component.html',
  styleUrls: ['./student-form.component.css']
})
export class StudentFormComponent implements OnInit {
  form: FormGroup;
  disabled = false;
  retunrUrl = '../list'
  listCourse = [];
  constructor(private fb: FormBuilder,
    private toastr: ToastrService,
    private courseService: CourseService,
    private studentService: StudentService,
    public activeRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.form = this.fb.group({
      id:[],
      status:[],
      name: ['', [Validators.required]],
      birthDate: ['', [Validators.required]],
      idCourse: ['', [Validators.required]],
    });
    const id = this.activeRoute.snapshot.params.id;
    if (id) {
      this.disabled = this.activeRoute.snapshot.data.detail ? true : false;
      this.retunrUrl = '../../list'
      this.getById(id);
    }
    this.getCourse();
  }
  getById(id) {
    this.studentService.httpGetId(id).subscribe(data => {
      if (data && data.status) {
        this.form.patchValue(data.object);
      }
    }), error => {
      console.log(error);
    };
    ;
  }
  getCourse() {
    this.courseService.httpGet().subscribe((data) => {
      if (data && data.status) {
        this.listCourse = data.object;
      } else {
        this.listCourse = [];
      }
    }), (error) => {
      this.toastr.error('Internal error!');
      console.log(error);
    }
  }
  save() {
    if (!this.form.valid) return;
    if(this.activeRoute.snapshot.params.id) {
      this.studentService.httpPut(this.form.value).subscribe((data) => {
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
      this.studentService.httpPost(this.form.value).subscribe((data) => {
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