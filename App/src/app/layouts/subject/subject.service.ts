import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { StandardService } from '../../service/Standart.service';
import { environment } from '../../../environments/environment';

import { Observable } from 'rxjs';

const url = `${environment.URL}/subject`;
@Injectable({
  providedIn: 'root'
})
export class SubjectService extends StandardService<any>  {
  constructor(
    protected http: HttpClient) {
    super(http, url, true)
  }
  getByCourse(id: number): Observable<any> {
    const params = new HttpParams().set('idCourse', id.toString());
    return this.http.get(this.url, { params });
  }
}
