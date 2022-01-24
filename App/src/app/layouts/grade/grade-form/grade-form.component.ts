import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CourseService } from '../../course/course.service';
import { StudentService } from '../../student/student.service';
import { SubjectService } from '../../subject/subject.service';
import { GradeService } from '../grade.service';

@Component({
  selector: 'app-grade-form',
  templateUrl: './grade-form.component.html',
  styleUrls: ['./grade-form.component.css']
})
export class GradeFormComponent implements OnInit {
  form: FormGroup;
  formFilter: FormGroup;
  disabled = false;
  retunrUrl = '../../../../student/list'
  listSubject = [];
  student = [];
  teacher: any;
  constructor(private fb: FormBuilder,
    private toastr: ToastrService,
    private subjectService: SubjectService,
    private studentService: StudentService,
    private gradeService: GradeService,
    public activeRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.getStudent();
    this.form = this.fb.group({
      id: [],
      fistGrade: [],
      secondGrade: [],
      thirdGrade: [],
      fourthgrade: [],
      subjectEntityId: [],
      gradeAvarage: [],
      studentEntityId: [this.activeRoute.snapshot.params.idStudent],
    });
    this.formFilter = this.fb.group({
      idSubject: ['', [Validators.required]],
    });
    this.getSubject();
  }
  getGrade() {
    const filter = { idSubject: this.formFilter.get('idSubject').value, idStudent: this.activeRoute.snapshot.params.idStudent }
    this.gradeService.getByStudentSubject(filter).subscribe(data => {
      if (data && data.status) {
        if(data.object) {
          this.form.patchValue(data.object[0]);
        } else {
          this.form.reset();
        }
        if(data.object[0] && data.object[0]) {
          this.teacher = data.object[0].subject.teacher
        } else {
          this.teacher = null;
        }
      }
    }), (error) => {
      console.log(error)
    };
  }
  getStudent() {
    this.studentService.getById(this.activeRoute.snapshot.params.idStudent).subscribe(data => {
      if (data && data.status) {
        this.student = data.object[0];
      }
    }), error => {
      console.log(error);
    };
  }
  getSubject() {
    this.subjectService.getByCourse(this.activeRoute.snapshot.params.idCourse).subscribe((data) => {
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
  calculateAverage() {
    this.form.get('gradeAvarage').setValue(
      ( Number(this.form.get('fistGrade').value ? this.form.get('fistGrade').value : 0)
      + Number(this.form.get('secondGrade').value ? this.form.get('secondGrade').value : 0)
      + Number(this.form.get('thirdGrade').value ? this.form.get('thirdGrade').value : 0)
      + Number(this.form.get('fourthgrade').value ? this.form.get('fourthgrade').value : 0))
      / 4);
  }
  save() {
    this.form.get('subjectEntityId').setValue(this.formFilter.get('idSubject').value)
    if (!this.form.valid) return;
    if (this.form.get('id').value) {
      this.gradeService.httpPut(this.form.value).subscribe((data) => {
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
      this.gradeService.httpPost(this.form.value).subscribe((data) => {
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