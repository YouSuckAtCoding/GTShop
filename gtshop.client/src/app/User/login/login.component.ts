import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, AbstractControl, AsyncValidatorFn } from '@angular/forms';
import { BaseComponent } from '../../base/base.component';
import { provideNativeDateAdapter } from '@angular/material/core';
import { User, UserService } from '../user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: false,

  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})

export class LoginComponent extends BaseComponent implements OnInit, OnDestroy {

    user?: User

  constructor(private service: UserService,
             private router: Router,) {
      super();
  }

  ngOnInit(): void {

    this.hideElements();

    this.form = new FormGroup({
      email: new FormControl('', [Validators.required, Validators.email]),
      pass: new FormControl('', Validators.required)
    });

  }

  ngOnDestroy(): void {
    
  }



  onSubmit() {

   

  }

}
