import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { debounceTime } from 'rxjs/operators';
import { environment } from '../../environments/environment';
import { StandardService } from '../service/Standart.service';

const url = `${environment.URL}/user`;

@Injectable({
  providedIn: 'root'
})
export class UsuarioService extends StandardService<any>  {
  constructor(
    protected http: HttpClient) {
    super(http, url, true)
  }
  Incluir(registro: any, callback?) {
     const formData = new FormData();
    formData.append('user', JSON.stringify(registro));
    this.http.post<any>(this.url, formData)
      .subscribe((resp: any) => {
        callback(resp);
      });
  }
  getFilter(filtro, callback?) {
    let params = new HttpParams()
      .set("nome", filtro.nome)
      .set("valor", filtro.valor);

    this.http.get(this.url, { params })
      .pipe(debounceTime(800))
      .subscribe((data: any) => {
        callback(data);
      });
  }

}
