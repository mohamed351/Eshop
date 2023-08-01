import { Component, OnInit } from '@angular/core';
import { Router, Routes } from '@angular/router';

@Component({
  selector: 'app-server-error',
  templateUrl: './server-error.component.html',
  styleUrls: ['./server-error.component.css']
})
export class ServerErrorComponent implements OnInit {

  error:any;
  constructor(private router:Router) {
    const currentNavigation = router.getCurrentNavigation();
    this.error =  currentNavigation?.extras.state?.['error']
    console.log(this.error);
   }

  ngOnInit(): void {
  }

}
