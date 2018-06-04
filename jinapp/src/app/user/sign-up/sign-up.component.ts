import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import {ToastrService} from 'ngx-toastr';
import { User } from '../../shared/user.model';
import { UserService } from '../../shared/user.service';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {
  user:User;
  emailPattern="^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$";
  public errorMsg;
  constructor(private userService:UserService,private toastr :ToastrService) { }

  ngOnInit() {
    this.resetForm();
  }
  resetForm(form?:NgForm){
    if(form!=null)
    form.reset();
    this.user={
      UserName:'',Password:'',Email:'',
      FirstName:'',LastName:''
    }
  }

  onSubmit(form:NgForm){
    this.userService.registerUser(form.value)
    .subscribe((data:any)=>{
      // console.log(data);
      // console.log("resulet:"+data.ok);
      if(data.Succeeded==true){
         this.resetForm(form);
         this.toastr.success('User registration successful');
        }else{
          // console.log('error in http client!')
          this.toastr.error(data.Errors[0]);
      }
    },
  error=>{
    //this.errorMsg=error;
    this.toastr.error(error);
              });
  }
}
//install NPM package for showing notification message 
//for success and error operations
// ngx-toaster
//npm install ngx-toastr --save
//import {BrowserAnimationsModule} from '@angular/platform-browser/animations';

//import {ToastrModule} from 'ngx-toastr';
/*
 imports: [
    BrowserModule,FormsModule,
    HttpClientModule,
    ToastrModule.forRoot(),
    BrowserAnimationsModule
  ],
import {ToastrService} from 'ngx-toastr';
*/
