import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable, map } from 'rxjs';
import { AccountService } from 'src/app/account/account.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private accoutService:AccountService , private router:Router){

  }
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean>{
    return this.accoutService.currentUser$.pipe(map(auth=>{

      if(auth) return true;
      else{
        console.log("executed");
        this.router.navigate(["/account/login"], {queryParams:{returnUrl:state.url}});
        return false;
      }
    }))
  }

}
