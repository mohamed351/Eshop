import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AccountService } from '../account.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm:FormGroup =new FormGroup({
    email:new FormControl('',[Validators.required, Validators.email]),
    password:new FormControl('',[Validators.required])
  })
  constructor(private accountService:AccountService, private router:Router) { }

  ngOnInit(): void {
  }
  onSubmit(){
    this.accountService.login(this.loginForm.value).subscribe(c=>{
       this.router.navigate(["/"]);
    });
  }

}
