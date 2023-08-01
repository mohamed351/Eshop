import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-testing-error',
  templateUrl: './testing-error.component.html',
  styleUrls: ['./testing-error.component.css']
})
export class TestingErrorComponent implements OnInit {

  baseUrl = environment.apiUrl;
  validationErrors:string[] = [];
  constructor(private httpClient:HttpClient) { }

  ngOnInit(): void {
  }
  get404Error(){
      this.httpClient.get(`${this.baseUrl}products/42`).subscribe({
        next: response => console.log(response),
        error: error => console.log(error),

      })
  }
  getServerError(){
    this.httpClient.get(`${this.baseUrl}Buggy/servererror`).subscribe({
      next: response => console.log(response),
      error: error => console.log(error),

    })
}
get400Error(){
  this.httpClient.get(`${this.baseUrl}Buggy/badrequest`).subscribe({
    next: response => console.log(response),
    error: error => console.log(error),

  })
}
get400ValidationError(){
  this.httpClient.get(`${this.baseUrl}products/ssss`).subscribe({
    next: response => console.log(response),
    error: error =>{
      this.validationErrors = error.errors;
    }

  })
}

}
