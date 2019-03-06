import { Component, OnInit } from '@angular/core';
import {NgForm} from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  onRegister(form: NgForm) {
    console.log(form);
  }

  onLogin(form: NgForm) {
    console.log(form);
  }

}
