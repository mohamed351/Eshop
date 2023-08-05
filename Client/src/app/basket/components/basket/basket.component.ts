import { Component, OnInit } from '@angular/core';
import { BasketService } from '../../services/basket.service';

@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrls: ['./basket.component.css']
})
export class BasketComponent implements OnInit {

  constructor(public basket:BasketService) { }

  ngOnInit(): void {
  }


}
