import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { StandardService } from '../../service/Standart.service';
import { environment } from '../../../environments/environment';

const url = `${environment.URL}/course`;

@Injectable({
  providedIn: 'root'
})

export class CourseService extends StandardService<any>  {
  constructor(
    protected http: HttpClient) {
    super(http, url, true)
  }
}