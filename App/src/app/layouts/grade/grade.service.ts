
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { StandardService } from '../../service/Standart.service';
import { environment } from '../../../environments/environment';
import { Observable } from 'rxjs';

const url = `${environment.URL}/grade`;
@Injectable({
  providedIn: 'root'
})

export class GradeService extends StandardService<any>  {
  constructor(
    protected http: HttpClient) {
    super(http, url, true)
  }
  
  getByStudentSubject(filter: any): Observable<ReturnView> {
    const params = new HttpParams().set('idSubject', filter.idSubject.toString())
                                   .set('idStudent', filter.idStudent.toString());
    return this.http.get<ReturnView>(this.url, { params });
  }
}
export interface ReturnView {
  status: boolean;
  object: GradeView[];
  message: string;
}
export interface GradeView {
    fistGrade: any;
    secondGrade: any;
    thirdGrade: any;
    fourthgrade: any;
    studentEntityId:number; 
    subjectEntityId: number;
    subject: any;
    
}