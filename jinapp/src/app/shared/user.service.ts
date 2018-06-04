import { Injectable } from '@angular/core';
import {HttpClient, HttpErrorResponse, HttpHeaders} from '@angular/common/http';
import {Response } from '@angular/http';
import {Observable} from 'rxjs';
import 'rxjs/add/operator/map';
import {User} from './user.model';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

@Injectable()
export class UserService {
  readonly rootUrl='http://localhost:3527';

  constructor(private http:HttpClient) { }

   public registerUser(user:User){
     const body:User = {
       UserName:user.UserName,
       Password:user.Password,
       Email:user.Email,
       FirstName:user.FirstName,
       LastName:user.LastName
     }
     return this.http.post(
       this.rootUrl+'/api/User/Register',body)
       .catch(this.errorPostHander);
   }
   errorPostHander(error:HttpErrorResponse){
     return Observable.throw(error.message||' Server Error!')
   }

   userAuthentication(userName, password) {
    var data = "username=" + userName + "&password=" + password + "&grant_type=password";
    var reqHeader = new HttpHeaders({ 'Content-Type': 'application/x-www-urlencoded','No-Auth':'True' });
    return this.http.post(this.rootUrl + '/token', data, { headers: reqHeader });
  }

  getUserClaims(){
   return  this.http.get(this.rootUrl+'/api/GetUserClaims');
  }
}
