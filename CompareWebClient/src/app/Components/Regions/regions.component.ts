import { Component, OnInit } from '@angular/core';
import { RegionService } from '../../Services/region.service';
import { Router } from '@angular/router';
import {Location} from '@angular/common';
import {AlertService} from '../../Services/alert.service'
import { OnDestroy } from "@angular/core";
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-regions',
  templateUrl: './regions.component.html',
  styleUrls: ['./regions.component.css']
})
export class RegionsComponent implements OnInit, OnDestroy {

  constructor( private regionService: RegionService,
    private router: Router,
    private _location: Location,
    private alertService: AlertService
  ) {
    this.subscription = new Subscription();
   }

  regionFirst:string;
  regionSecond:string;
  regionQuestionID;
  loading:boolean = true;
  noQuestion:boolean = false;
  subscription:Subscription;
  
  AnswerQuestion(answer){
    this.subscription.add(this.regionService.answerQuestion(this.regionQuestionID, answer)
    .subscribe(
      (data) => {
        if(data){
          this.GetNextQuestion();
        }
      },
      (error) => {
        
        this.alertService.errorFromResponse(error);
      }

    ));
    
  }

  Refresh(){
    this.alertService.clear();
    this.GetNextQuestion();
  }

  GetNextQuestion(){
    this.regionFirst = "Region";
    this.regionSecond = "Region";
    this.regionQuestionID = 0;
    this.loading = true;

    this.subscription.add(this.regionService.getNextQuestion().subscribe(
      (data) => {
        if(data){
          this.noQuestion = false;

          this.regionFirst = data.regionOne;
          this.regionSecond = data.regionTwo;
          this.regionQuestionID = data.regionQuestionID;
        }
        else{
          this.alertService.error("There are no questions for this criteria right now.");
          this.noQuestion = true;

        }
        this.loading = false;
      },
      (error) => {
        
        this.alertService.errorFromResponse(error);
        this.loading = false;
      }
    ));
  }

  NavigateBack(){
    this._location.back();
  }


  ngOnInit() {
    this.GetNextQuestion();
  }
  ngOnDestroy(){
    this.subscription.unsubscribe();
  }

}
