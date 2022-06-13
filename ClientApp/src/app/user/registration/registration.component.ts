import { Component, Input, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { UserService } from 'src/app/Service/user.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  constructor(public userService: UserService, private toastr:ToastrService) { }

  ngOnInit(): void {  
    this.userService.formModel.reset();
  }


  //variables
  selectedRole:any;

  onSubmit() {
    this.userService.register().subscribe(
      (res: any) => {
        if (res.succeeded) {
          this.userService.formModel.reset();
          this.toastr.success('New user created', 'Registration succesful');
        } else {
          res.errors.forEach(element => {
            switch (element.code) {
              case 'DuplicateUserName':
                this.toastr.error('Username is already taken', 'Registration failed');
                break;
              default:
                this.toastr.error(element.description, 'Registration failed');

                break;
            }
          });
        }
      },
      err => {
        console.log(err);
      }
    )
  }
}
