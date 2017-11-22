import { Headers } from '@angular/http';
import { Component, NgModule, OnInit } from '@angular/core';
import { FormBuilder, Validators  } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { User } from '../../models/user';
import { LoginService } from './../../services/login-service.service';
import { NotifService } from './../../services/notif-service.service';
 
 
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  EMAIL_REGEXP = "^[a-z0-9!#$%&'*+\/=?^_`{|}~.-]+@[a-z0-9]([a-z0-9-]*[a-z0-9])?(\.[a-z0-9]([a-z0-9-]*[a-z0-9])?)*$";
  model : User;
  loading = false;
  message = "";
  busy: Promise<any>;

  constructor(
      private router: Router,
      private notifService : NotifService,
      private loginService : LoginService
    ) { 
      this.model = new User();
    }


  ngOnInit() {
      localStorage.removeItem('loggedUser');
      this.loading = false;   
      this.loginService.logout().then(resp => {
        this.loginService.loginSubject.next(1);     
      });
  }

  ngDestroy()
  {
  }
   
  login() {
    //clean notifications message on page
    this.notifService.subject.next();
    this.loading = true;
    this.busy =  this.loginService.login(this.model).then(resp => {
        this.loading = false;
        localStorage.setItem('loggedUser', this.model.email);
        this.loginService.loginSubject.next(1);
        this.router.navigate(["/list"]);
      }).catch(exp => {
          this.notifService.error(exp._body);
          this.loading = false;
      }) ;
 
    } 
}
