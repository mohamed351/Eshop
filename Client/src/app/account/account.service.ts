import { Injectable } from '@angular/core';
import { BehaviorSubject , ReplaySubject, map, of} from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../models/user';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
 baseUrl = environment.apiUrl;
 private currentUserSource = new ReplaySubject<User |null>(1);
currentUser$ = this.currentUserSource.asObservable();
  constructor(private http:HttpClient, private router:Router) { }

  loadCurrentUser(token:string |null){
    if(!token){
      console.log(token);

      this.currentUserSource.next(null);
      return of(null);
    }
    let header = new HttpHeaders();
    header = header.set("Authorization", `Bearer ${token}`)
    return this.http.get<User>(`${this.baseUrl}account`,{headers:header}).pipe(
      map((user) =>{
        if(user){
        localStorage.getItem("token")
        this.currentUserSource.next(user);
        return user;
        }
        else{
          return null;
        }
      })
    )
  }
  login(values:any){
    return this.http.post<User>(`${this.baseUrl}account/login`, values)
    .pipe(map(user =>{
      localStorage.setItem("token",user.token);
      this.currentUserSource.next(user);
      return user;
    }))
  }
  regiter(values:any){
    return this.http.post<User>(`${this.baseUrl}account/register`, values)
    .pipe(map(user =>{
      localStorage.setItem("token",user.token);
      this.currentUserSource.next(user);
    }))
  }
  checkEmailExist(email:string){
    return this.http.get(`${this.baseUrl}account/emailexists?email=${email}`);
  }
  logout(){
    localStorage.removeItem("token");
    this.currentUserSource.next(null);
    this.router.navigateByUrl("/");

  }
}
