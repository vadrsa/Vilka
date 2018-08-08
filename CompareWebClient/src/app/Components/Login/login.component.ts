import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { User } from '../../Entities/User';
import { AuthenticationService } from '../../Services/authentication.service';
import { AlertService } from '../../Services/alert.service';
import { OnDestroy } from "@angular/core";
import { Subscription } from 'rxjs';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit, OnDestroy {
  
  loading = false;
  returnUrl: string;
  subscription:Subscription;
  user: User;

  constructor(
    private authenticationService : AuthenticationService,
    private route: ActivatedRoute,
    private router: Router,
    private alertService: AlertService) { }

  ngOnInit() {
    this.authenticationService.logout();
    this.user = new User();
    this.user.email = "dav@a.a";
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
    this.subscription = new Subscription();
  }
  
  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  login(){
    this.loading = true;
    this.subscription.add(this.authenticationService.login(this.user)
      .subscribe(
      (key) => { this.router.navigate([this.returnUrl]); },
      (error) => {
        this.alertService.errorFromResponse(error);
        this.loading = false;
      }
    ));
  }

}
