import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
export class FooterComponent implements OnInit {
  date: Date = new Date();
  year: string;

  constructor(private datePipe: DatePipe) { 
    this.year = this.datePipe.transform(this.date, 'yyyy');
  }

  ngOnInit(): void {
  }

}
