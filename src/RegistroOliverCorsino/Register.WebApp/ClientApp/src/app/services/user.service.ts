import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  restisterUrl = `${environment.apiUrl}/users`;

  constructor(private http: HttpClient) { }

  validateIdentificationNumber(identificationNumber: string) {
    return this.http.get<User>(`${this.restisterUrl}/${identificationNumber}`);
  }

}
