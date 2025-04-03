import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, AbstractControl, AsyncValidatorFn } from '@angular/forms';
import { BaseComponent } from '../../base/base.component';
import { provideNativeDateAdapter } from '@angular/material/core';
import { fromEvent } from 'rxjs';
import { User, UserService } from '../user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  standalone: false,
  providers: [provideNativeDateAdapter()],
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss'
})
export class RegisterComponent extends BaseComponent implements OnInit, OnDestroy{
  user?: User;

  constructor(private service: UserService,
    private router: Router,) {
    super();
  }    

  ngOnInit() {

    this.hideElements();

    fromEvent(window, 'popstate').subscribe(() => {
      this.showElements();
    })

    this.form = new FormGroup({
      name: new FormControl('' , Validators.required),
      email: new FormControl('', [Validators.required, Validators.email]),
      date: new FormControl('' , Validators.required),
      pass: new FormControl('' , Validators.required),
      cpass: new FormControl('', Validators.required)
    });
  }

  ngOnDestroy(): void {
    this.showElements();
  } 


  onSubmit() {
    this.user = <User>{}

    this.user.name = this.form.controls['name'].value;
    this.user.email = this.form.controls['email'].value;
    this.user.birthDate = this.form.controls['date'].value;
    this.user.password = this.form.controls['pass'].value;

    this.service.put(this.user)
      .subscribe({
        next: (result) => {
          console.log("User has been created.");

          // go back to countries view
          this.router.navigate(['/']);
        },
        error: (error) => console.error(error)
      });
  }
}
