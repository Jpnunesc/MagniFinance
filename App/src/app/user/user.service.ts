import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { debounceTime } from 'rxjs/operators';
import { environment } from '../../environments/environment';
import { StandardService } from '../service/Standart.service';

const url = `${environment.URL}/user`;

@Injectable({
  providedIn: 'root'
})
export class UserService extends StandardService<any>  {
  constructor(
    protected http: HttpClient) {
    super(http, url, true)
  }
}
