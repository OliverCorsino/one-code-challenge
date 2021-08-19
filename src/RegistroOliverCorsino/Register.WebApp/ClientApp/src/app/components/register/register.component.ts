import { UserService } from './../../services/user.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html'
})
export class RegisterComponent implements OnInit {

  registerForm!: FormGroup;

  constructor(private formBuilder: FormBuilder, private userService: UserService) { }

  ngOnInit() {
    this.buildForm();
  }

  onSubmit() {
    const identificationNumber = this.registerForm.controls['identificationNumber'].value;
    this.userService.validateIdentificationNumber(identificationNumber).subscribe((result) => {
      console.log(result);
    });
  }

  private buildForm(): void {
    this.registerForm = this.formBuilder.group({
      identificationNumber: new FormControl('', [Validators.required, Validators.minLength(13), Validators.maxLength(13)])
    });
  }

}
