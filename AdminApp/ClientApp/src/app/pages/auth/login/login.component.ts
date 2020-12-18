import { Component, OnInit, OnDestroy } from '@angular/core';
import {AuthService} from '../../../services/auth/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit, OnDestroy {


  user: string;
  password: string;

  constructor(
    private authService: AuthService
  ) {}

  ngOnInit() {
  }
  ngOnDestroy() {
  }

  login() {
    this.authService.logIn(this.user, this.password);
  }

}
