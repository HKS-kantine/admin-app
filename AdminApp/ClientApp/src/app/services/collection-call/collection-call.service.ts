import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {environment} from '../../../environments/environment';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CollectionCallService {

  constructor(private http: HttpClient) { }

  delete(url: string): Observable<any> {
    return this.http.delete(`${environment.collectionURL}${url}`, {withCredentials: true});
  }

  get(url: string): Observable<any> {
    return this.http.get(`${environment.collectionURL}${url}`, {withCredentials: true});
  }

  post(url: string, data: object): Observable<any> {
    return this.http.post(`${environment.collectionURL}${url}`, data, {withCredentials: true});
  }

  put(url: string, data: object): Observable<any> {
    return this.http.put(`${environment.collectionURL}${url}`, data, {withCredentials: true});
  }
}
