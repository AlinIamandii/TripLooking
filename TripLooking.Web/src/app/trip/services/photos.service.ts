import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PhotosService {
  private endpoint: string = 'http://trip-looking.ashbell-platform.com/api/v1/trips';

  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${JSON.parse(localStorage.getItem('userToken'))}`
    })
  };

  constructor(private readonly http: HttpClient) { }

  get(tripId: string): Observable<Blob[]> {
    return this.http.get<Blob[]>(`${this.endpoint}/${tripId}/photos`, this.httpOptions);
  }

  post(tripId: string, data: any): Observable<any> {
    return this.http.post<any>(`${this.endpoint}/${tripId}/photos`, { Content: data }, this.httpOptions);
  }
}