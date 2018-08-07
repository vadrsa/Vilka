import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { User } from '../../Entities/User';
import { AuthenticationService } from '../../Services/authentication.service';
import { AlertService } from '../../Services/alert.service';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  
  loading = false;
  returnUrl: string;

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
    this.user.password = "_Marusel2010";
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  login(){
    this.loading = true;
    this.authenticationService.login(this.user)
      .subscribe(
      (key) => { this.router.navigate([this.returnUrl]); },
      (error) => {
        console.log(error);
        this.alertService.error(error.error.error);
        this.loading = false;
      }
    );
  }

}
