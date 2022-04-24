import { Component, OnInit } from '@angular/core';
import { Physician } from 'src/app/core/models/physician';
import { AccountService } from 'src/app/core/services/account.service';
import { PhysicianService } from 'src/app/core/services/physician.service';

@Component({
  selector: 'app-physicians-list',
  templateUrl: './physicians-list.component.html',
  styleUrls: ['./physicians-list.component.css']
})
export class PhysiciansListComponent implements OnInit {

  physician: Physician;
  physicians: Physician[];

  constructor(private physicianService: PhysicianService) { }

  ngOnInit(): void {
    this.loadPhysicians();
  }

  loadPhysicians() {
    this.physicianService.getPhysicians().subscribe(physicians => {
      this.physicians = physicians;
    });
  }
}
