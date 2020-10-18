import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class TurnService {
  apiUri = '/customersInTurn';

  constructor(private http: HttpClient) { }

  getNextTurn(serviceId): Observable<any> {
    return this.http.get(environment.apiUrl + this.apiUri + "/" + serviceId)
  }

  completeTurn(turn:any):Observable<any>{
    return this.http.put(environment.apiUrl + this.apiUri,turn)
  }
}
