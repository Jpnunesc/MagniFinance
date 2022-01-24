import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CourseService } from '../../course/course.service';
import { TeacherService } from '../../teacher/teacher.service';
import { SubjectService } from '../subject.service';

@Component({
  selector: 'app-subject-form',
  templateUrl: './subject-form.component.html',
  styleUrls: ['./subject-form.component.css']
})
export class SubjectFormComponent implements OnInit {
  form: FormGroup;
  disabled = false;
  retunrUrl = '../list'
  listCourse = [];
  listTeacher = [];
  constructor(private fb: FormBuilder,
    private toastr: ToastrService,
    private courseService: CourseService,
    private teacherService: TeacherService,
    private subjectService: SubjectService,
    public activeRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.form = this.fb.group({
      id:[],
      status:[],
      name: ['', [Validators.required]],
      average: ['', [Validators.required]],
      idCourse: ['', [Validators.required]],
      teacherEntityId : ['', [Validators.required]]
    });
    const id = this.activeRoute.snapshot.params.id;
    if (id) {
      this.disabled = this.activeRoute.snapshot.data.detail ? true : false;
      this.retunrUrl = '../../list'
      this.getById(id);
    }
    this.getCourse();
    this.getTeacher();
  }
  getById(id) {
    this.subjectService.httpGetId(id).subscribe(data => {
      if (data && data.status) {
        this.form.patchValue(data.object);
      }
    }), error => {
      console.log(error);
    };
    ;
  }
  getTeacher() {
    this.teacherService.httpGet().subscribe((data) => {
      if (data && data.status) {
        console.log(data.object);
        this.listTeacher = data.object;
      } else {
        this.listTeacher = [];
      }
    }), (error) => {
      this.toastr.error('Internal error!');
      console.log(error);
    }
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
      this.subjectService.httpPut(this.form.value).subscribe((data) => {
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
      this.subjectService.httpPost(this.form.value).subscribe((data) => {
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
