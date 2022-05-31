import { Injectable } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private fb: FormBuilder, private http:HttpClient) { }

  readonly userRegistrationApiUrl = "https://localhost:7136/api"

  formModel = this.fb.group({
    UserName: ['', Validators.required],
    FirstName: [''],
    LastName: [''],
    Email: ['', Validators.email],
    Passwords: this.fb.group({
      Password: ['', [Validators.required, Validators.minLength(6)]],
      ConfirmPassword: ['', Validators.required]
    }, { validator: this.comparePasswords }),

  })

  comparePasswords(fb: FormGroup) {
    let confirmPasswControl = fb.get('ConfirmPassword');
    if (confirmPasswControl?.errors == null || 'passwordMismatch' in confirmPasswControl?.errors) {
      if (fb.get('Password')?.value != confirmPasswControl?.value)
        confirmPasswControl?.setErrors({ passwordMismatch: true });
      else
        confirmPasswControl?.setErrors(null);
    }
  }

  register(){
    var body = {
      UserName : this.formModel.value.UserName,
      FirstName : this.formModel.value.FirstName,
      LastName : this.formModel.value.LastName,
      Email : this.formModel.value.Email,
      Password:this.formModel.value.Passwords.Password,
    };
    return this.http.post(this.userRegistrationApiUrl + '/AppUser/Register', body)
  }

  login(formData){
    return this.http.post(this.userRegistrationApiUrl + '/AppUser/Login', formData)
  }
  
  getUserProfile(){
    return this.http.get(this.userRegistrationApiUrl+ '/UserProfile');
  }
}
