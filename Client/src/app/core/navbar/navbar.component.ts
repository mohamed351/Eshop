import { Component, OnInit } from '@angular/core';
import { BasketService } from 'src/app/basket/services/basket.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  constructor(public basketService:BasketService) { }

  ngOnInit(): void {
  }

}
