import { Injectable, Inject } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class HttpServiceService {

  url: string;
  headerOptions: HttpHeaders;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.url = baseUrl;
    this.headerOptions = new HttpHeaders();
    this.headerOptions.set('Content-Type', 'application/json');
  }

  public getMetrics(input: string): Observable<any> {
    console.log(input);
    const param = {
      text: input,
    };

    return this.http.post<any>(this.url + `text/metrics`, param, {headers: this.headerOptions});
  }
}
