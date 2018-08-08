import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../Entities/User';
import { Config } from '../Helpers/config';
@Injectable({
  providedIn: 'root'
})
export class RegionService {
  

  constructor(
    private http: HttpClient,
  ) { }

  getNextQuestion() : Observable<any>{
    return this.http.get<any>(Config.apiUrl + 'region/question');
  }

  answerQuestion(questionID, answer){
    return this.http.post<boolean>(Config.apiUrl + 'region/answer', { regionQuestionID: questionID, answer: answer});
  }
}
