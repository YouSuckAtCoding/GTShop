import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment.development'
import { ApiResult, BaseService } from '../base.service';
import { Injectable } from '@angular/core';


@Injectable({
  providedIn: 'root',
})
export class UserService extends BaseService<User> {

  constructor(
    http: HttpClient) {
    super(http);
  }

  override getData(pageIndex: number, pageSize: number, sortColumn: string, sortOrder: string, filterColumn: string | null, filterQuery: string | null): Observable<ApiResult<User>> {
        throw new Error('Method not implemented.');
    }
    override get(id: number): Observable<User> {
        throw new Error('Method not implemented.');
    }
    override put(item: User): Observable<User> {
        throw new Error('Method not implemented.');
    }
    override post(item: User): Observable<User> {
      var url = this.getUrl("/register")
      return this.http.post<User>(url, item);
    }

}


export interface User {
  name: string,
  password: string,
  email: string,
  birthDate: Date,
  ssn: string,
  country: number,
  city: string,
  phone: string

}
