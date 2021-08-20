import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from './../../environments/environment';
import { ContactInformationType } from './../models/contact-information-type';

@Injectable({
  providedIn: 'root'
})
export class ContactInformationTypeService {

  private contactInformationTypeUrl = `${environment.apiUrl}/contact-information-types`;

  constructor(private http: HttpClient) { }

  getAll() {
    return this.http.get<ContactInformationType[]>(this.contactInformationTypeUrl);
  }

}
