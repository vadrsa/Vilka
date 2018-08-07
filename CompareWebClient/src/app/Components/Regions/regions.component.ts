import { Component, OnInit } from '@angular/core';
import { RegionService } from '../../Services/region.service';
import { Router } from '@angular/router';
import {Location} from '@angular/common';
import {AlertService} from '../../Services/alert.service'
@Component({
  selector: 'app-regions',
  templateUrl: './regions.component.html',
  styleUrls: ['./regions.component.css']
})
export class RegionsComponent implements OnInit {

  constructor( private regionService: RegionService,
    private router: Router,
    private _location: Location
    private alertService: AlertService
  ) { }

  regionFirst:string;
  regionSecond:string;
  regionQuestionID;
  loading:boolean = true;

  
  AnswerQuestion(answer){
    console.log(answer);
    this.regionService.answerQuestion(this.regionQuestionID, answer)
    .subscribe(
      (data) => {
        console.log(data);
        if(data){
          this.GetNextQuestion();
        }
      },
      (error) => {
        this.alertService.error(error.error.error);
      }

    );
    
  }

  GetNextQuestion(){
    this.loading = true;
    this.regionService.getNextQuestion().subscribe(
      (data) => {
        if(data){
          this.regionFirst = data.regionOne;
          this.regionSecond = data.regionTwo;
          this.regionQuestionID = data.regionQuestionID;
          this.loading = false;
        }
        else{
          this.alertService.error("There are no questions for this criteria right now.");

        }
      },
      (error) => {
        this.alertService.error(error.error.error);

      }
    );
  }

  NavigateBack(){
    this._location.back();
  }


  ngOnInit() {
    this.GetNextQuestion();
  }

}
