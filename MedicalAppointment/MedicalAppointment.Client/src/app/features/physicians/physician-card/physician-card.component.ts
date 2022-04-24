import { Component, Input, OnInit } from '@angular/core';
import { Physician } from 'src/app/core/models/physician';
import { AccountService } from 'src/app/core/services/account.service';

@Component({
  selector: 'app-physician-card',
  templateUrl: './physician-card.component.html',
  styleUrls: ['./physician-card.component.css']
})
export class PhysicianCardComponent implements OnInit {

  @Input() physician: Physician;

  constructor(public accountService: AccountService) { }

  ngOnInit(): void {
  }

}
