import { User } from './../../models/user';
import { ContactInformationTypeService } from '../../services/contact-information-type.service';
import { ContactInformationType } from '../../models/contact-information-type';
import { EducationLevelService } from '../../services/education-level.service';
import { EducationLevel } from '../../models/education-level';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { UserService } from '../../services/user.service';
import { ContactInformation } from 'src/app/models/contact-information';

@Component({
  selector: 'app-about',
  templateUrl: './user-info.component.html'
})
export class UserInfoComponent implements OnInit {

  userInfoForm!: FormGroup;
  displayModal = false;
  displayContactInformationError = false;
  educationLevels: EducationLevel[];
  contactInformationType: ContactInformationType[];
  contactInformations: ContactInformation[] = [];
  currentIdentificationNumber: string;

  constructor(
    private formBuilder: FormBuilder,
    private userService: UserService,
    private educationLevelService: EducationLevelService,
    private contactInformationTypeService: ContactInformationTypeService,
    private router: Router,
    private activeRoute: ActivatedRoute
  ) { }

  ngOnInit() {
    this.buildForm();
    this.loadEducationLevels();
    this.loadContactInformationTypes();

    this.currentIdentificationNumber = this.activeRoute.snapshot.paramMap.get('identificationNumber');
  }

  openModal() {
    this.displayModal = true;
  }

  addContactInfo() { }

  goBack() {
    this.router.navigate(['']);
  }

  onSubmit() {
    // this.contactInformation.length === 0 ? this.displayContactInformationError = true : this.displayContactInformationError = false;
    const user = this.userInfoForm.getRawValue() as User;
    user.contactInformations = this.contactInformations;
    user.identificationNumber = this.currentIdentificationNumber;

    this.userService.save(user).subscribe(() => {
      this.goBack();
    }, (error) => {
      console.error(error);
    });
  }

  private buildForm(): void {
    this.userInfoForm = this.formBuilder.group({
      name: new FormControl('', [Validators.required, Validators.maxLength(100)]),
      lastName: new FormControl('', [Validators.required, Validators.maxLength(100)]),
      dateOfBirth: new FormControl('', [Validators.required]),
      educationLevelId: new FormControl(0, [Validators.required, Validators.min(1)])
    });
  }

  private loadEducationLevels() {
    this.educationLevelService.getAll().subscribe((result) => {
      this.educationLevels = result;
    }, (error) => {
      console.error(error);
    });
  }

  private loadContactInformationTypes() {
    this.contactInformationTypeService.getAll().subscribe((result) => {
      this.contactInformationType = result;
    }, (error) => {
      console.error(error);
    });
  }

}
