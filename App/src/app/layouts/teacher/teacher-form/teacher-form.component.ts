import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { SubjectService } from '../../subject/subject.service';
import { TeacherService } from '../teacher.service';

@Component({
  selector: 'app-teacher-form',
  templateUrl: './teacher-form.component.html',
  styleUrls: ['./teacher-form.component.css']
})
export class TeacherFormComponent implements OnInit {
  form: FormGroup;
  disabled = false;
  retunrUrl = '../list'
  listSubject = [];
  constructor(private fb: FormBuilder,
    private toastr: ToastrService,
    private teacherService: TeacherService,
    private subjectService: SubjectService,
    public activeRoute: ActivatedRoute,
    private router: Router) { }

  ngOnInit(): void {
    this.form = this.fb.group({
      id:[''],
      status:[''],
      name: [{ value: ''}, [Validators.required]],
      birthDate: [{ value: ''}, [Validators.required]],
      remuneration: [{ value: ''}, [Validators.required]],
      idSubject: [{ value: ''}, [Validators.required]]
    });
    const id = this.activeRoute.snapshot.params.id;
    if (id) {
      this.disabled = this.activeRoute.snapshot.data.detail ? true : false;
      this.retunrUrl = '../../list'
      this.getTeacherById(id);
    }
    this.getSubject();
  }
  getTeacherById(id) {
    this.teacherService.httpGetId(id).subscribe(data => {
      if (data && data.status) {
        this.form.patchValue(data.object);
        let date = new Date(data.object.birthDate);
        let dataFormatada = new Date(String(date.getDate()).padStart(2,'0') + "/" + String(date.getMonth() + 1).padStart(2,'0') + "/" + date.getFullYear()); 
        this.form.get('birthDate').setValue(dataFormatada);
      }
    }), error => {
      console.log(error);
    };
    ;
  }
  getSubject() {
    this.subjectService.httpGet().subscribe((data) => {
      if (data && data.status) {
        this.listSubject = data.object;
      } else {
        this.listSubject = [];
      }
    }), (error) => {
      this.toastr.error('Internal error!');
      console.log(error);
    }
  }
  save() {
    if (!this.form.valid) return;
    if(this.activeRoute.snapshot.params.id) {
      // this.form.get('id').setValue(Number(this.activeRoute.snapshot.params.id))
      this.teacherService.httpPut(this.form.value).subscribe((data) => {
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
      this.teacherService.httpPost(this.form.value).subscribe((data) => {
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
