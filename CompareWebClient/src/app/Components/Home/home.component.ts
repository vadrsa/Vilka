import { Component, OnInit } from '@angular/core';
import { User } from '../../Entities/User';
import { Router } from '@angular/router';
import { OnDestroy } from "@angular/core";
import { Subscription } from 'rxjs';
import { AuthenticationService } from '../../Services/authentication.service';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit, OnDestroy {
  subscription:Subscription;
  currentUser;
  connecting:boolean;
  constructor(
    private router: Router,
    private authenticationService: AuthenticationService
   ) { 
    this.currentUser = JSON.parse(localStorage.getItem('currentUser'));
    this.subscription = new Subscription();
  }

  ngOnInit() {
    this.authenticationService.connectServer().subscribe(
      (data) => {

      },
      (error)=>{
        console.log(error);
      }
    );
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  compareRegions(){
    this.router.navigate(['/regions/']);
  }

}
