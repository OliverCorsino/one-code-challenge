import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from './../../environments/environment';
import { EducationLevel } from './../models/education-level';

@Injectable({
  providedIn: 'root'
})
export class EducationLevelService {

  private educationLevelUrl = `${environment.apiUrl}/education-levels`;

  constructor(private http: HttpClient) { }

  getAll() {
    return this.http.get<EducationLevel[]>(this.educationLevelUrl);
  }

}
