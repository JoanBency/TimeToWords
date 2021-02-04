import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { HttpClient } from '@angular/common/http';
//import { Time } from '@angular/common';

@Component({
  selector: 'conversion',
  templateUrl: require('./conversion.component.html')
})
export class ConversionComponent{
  public time: Time;

  constructor(private http: HttpClient) { }

  public getTimeInWords(time_num1: string) {

    this.http.get<Time>('/api/Conversion/towords/' + time_num1).subscribe(result => {
      this.time = result;
    });
  }
}

interface Time {
  time_num: string;
  TimeinWords: string;
}

