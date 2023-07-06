import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { UserDetailsService } from '../user-details.service';
import instance from '../axios.config';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
})
export class LoginComponent implements OnInit {
  hide: boolean = false;
  userDetails: any;

  constructor(
    private fb: FormBuilder,
    private userDetailsService: UserDetailsService
  ) {}

  ngOnInit() {}

  loginForm: FormGroup = this.fb.group({
    email: ['', [Validators.required, Validators.email]],
    password: ['', [Validators.required, Validators.minLength(6)]],
  });

  onLogin() {
    if (!this.loginForm.valid) {
      return;
    }

    this.fetchUserDetails();
  }

  async fetchUserDetails() {
    try {
      const userDetails = await this.userDetailsService.getUserDetails();
      // Convert userDetails to JSON
      const userDetailsJSON = JSON.stringify(userDetails);
      // console.log(userDetailsJSON);

      instance
        .post('/', userDetailsJSON)
        .then((response) => {
          console.log('Response:', response.data);
        })
        .catch((err) => {
          console.error('Error:', err);
        });
    } catch (error) {
      console.error('Error retrieving user details:', error);
    }
  }
}
