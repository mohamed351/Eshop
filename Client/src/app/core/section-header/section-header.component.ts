import { Component, OnInit } from '@angular/core';
import { BreadcrumbService } from 'xng-breadcrumb';

@Component({
  selector: 'app-section-header',
  templateUrl: './section-header.component.html',
  styleUrls: ['./section-header.component.css']
})
export class SectionHeaderComponent implements OnInit {


  constructor(public bsService:BreadcrumbService) { }

  ngOnInit(): void {
    this.bsService.breadcrumbs$.subscribe(a=>{
      console.log(a);
    })
  }
  onElementClick( testing:any){


  }

}
