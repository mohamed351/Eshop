import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, ValidatorFn, Validators } from '@angular/forms';
import { AccountService } from '../account.service';
import { Router } from '@angular/router';
import { debounceTime, map, switchMap, take } from 'rxjs';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  errors:string[] = [];
  constructor(private formBuilder:FormBuilder, private accountService:AccountService , private router:Router) { }
   complexPassword ="(?=^.{6,10}$)(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\s).*$"
  ngOnInit(): void {
  }
  registerForm = this.formBuilder.group({
    displayName: [null,[Validators.required]],
    email:[null, [Validators.required,Validators.email],[this.validateEmailExist()]],
    password:[null,[Validators.required, Validators.pattern(this.complexPassword) ]]
  })
  onSubmit(){
    this.accountService.regiter(this.registerForm.value).subscribe({
      next:()=> this.router.navigateByUrl("/shop"),
      error:(error)=>{
         this.errors =error.errors
        }
    })
  }
  validateEmailExist():ValidatorFn{
    return (control:AbstractControl)=>{
     return  control.valueChanges.pipe(debounceTime(500),
      take(1)
      ,switchMap(()=>{
        return  this.accountService.checkEmailExist(control.value).pipe(map(result=>{
          return result ? {emailExists:true}:null
        }))
      }))

    }
  }

}
