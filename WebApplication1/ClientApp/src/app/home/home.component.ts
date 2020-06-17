import { MetricResponse } from '../domain/metric';
import { HttpServiceService } from '../domain/httpService.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  metric: MetricResponse;
  private textareaValue = '';
  public message = 'Try our service !';


  constructor(private httpService: HttpServiceService) {
  }

  ngOnInit(): void {}

  doTextareaValueChange(ev) {
    try {
      this.textareaValue = ev.target.value;
    } catch (e) {
      console.log('could not set textarea-value');
    }
  }

  analyze() {
    if (this.textareaValue.length === 0) {
      this.message = 'Text is empty, please write at list one symbol';
      this.metric = undefined;
    } else {
      this.httpService.getMetrics(this.textareaValue).subscribe(data => {
        console.log(data);
        this.metric = data;
      });
    }

    setTimeout(() => {
      this.message = 'Try our service !';
    }, 5000);
  }
}
