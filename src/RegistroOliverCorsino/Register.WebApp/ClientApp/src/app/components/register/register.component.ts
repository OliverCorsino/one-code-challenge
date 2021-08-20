import { UserService } from './../../services/user.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html'
})
export class RegisterComponent implements OnInit {

  registerForm!: FormGroup;
  currentIdentificationNumber: string;
  displayInfoMessage = false;

  constructor(private formBuilder: FormBuilder, private userService: UserService) { }

  ngOnInit() {
    this.buildForm();
  }

  onSubmit() {
    this.currentIdentificationNumber = this.registerForm.controls['identificationNumber'].value;
    this.userService.validateIdentificationNumber(this.currentIdentificationNumber).subscribe((result) => {
      result ? this.displayInfoMessage = true : this.displayInfoMessage = false;
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
