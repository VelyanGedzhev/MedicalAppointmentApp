import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Physician } from 'src/app/core/models/physician';
import { PhysicianService } from 'src/app/core/services/physician.service';

@Component({
  selector: 'app-physician-details',
  templateUrl: './physician-details.component.html',
  styleUrls: ['./physician-details.component.css']
})
export class PhysicianDetailsComponent implements OnInit {
  physician: Physician;

  constructor(private physicianService: PhysicianService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.loadPhysician();
  }

  loadPhysician() {
    this.physicianService.getPhysician(this.route.snapshot.paramMap.get('id')).subscribe(physician => {
      this.physician = physician;
    });
  }
}
