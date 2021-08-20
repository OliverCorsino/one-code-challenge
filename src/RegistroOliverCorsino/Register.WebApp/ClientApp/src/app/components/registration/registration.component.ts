import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './registration.component.html'
})
export class RegistrationComponent implements OnInit {

  registerForm!: FormGroup;
  currentIdentificationNumber: string;
  displayInfoMessage = false;

  constructor(private formBuilder: FormBuilder, private userService: UserService, private router: Router) { }

  ngOnInit() {
    this.buildForm();
  }

  onSubmit() {
    this.currentIdentificationNumber = this.registerForm.controls['identificationNumber'].value;
    this.userService.validateIdentificationNumber(this.currentIdentificationNumber).subscribe((result) => {
      if (result) {
        this.displayInfoMessage = true;
      } else {
        this.displayInfoMessage = false;
        this.router.navigate(['/about']);
      }
    });
  }

  goToDetails() {
  }

  private buildForm(): void {
    this.registerForm = this.formBuilder.group({
      identificationNumber: new FormControl('', [Validators.required, Validators.minLength(13), Validators.maxLength(13)])
    });
  }

}
