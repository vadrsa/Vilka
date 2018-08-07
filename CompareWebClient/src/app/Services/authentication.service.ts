import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../Entities/User';
import { Config } from '../Helpers/config';
import { from } from 'rxjs';
import { map } from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  

  constructor(
    private http: HttpClient,
  ) {
  }

  login(user: User ) : Observable<any>{
    return this.http.post<any>(Config.apiUrl + 'account/login', user).pipe(map(user => {
      console.log(user);
      // login successful if there's a jwt token in the response
      if (user && user.token) {
        
          // store user details and jwt token in local storage to keep user logged in between page refreshes
          localStorage.setItem('currentUser', JSON.stringify(user));
      }

      return user;
    }));
  }

  logout() {
    // remove user from local storage to log user out
    localStorage.removeItem('currentUser');
  } 
}
