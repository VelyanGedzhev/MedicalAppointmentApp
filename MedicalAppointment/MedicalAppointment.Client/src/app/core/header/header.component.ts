import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { User } from '../models/user';
import { AccountService } from '../services/account.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  model: any = {};

  constructor(
    public accountService: AccountService, 
    private router: Router,
    private toastr: ToastrService) { }

  ngOnInit(): void {
  }
  
  login() {
    this.accountService.login(this.model).subscribe(response => {
      this.router.navigateByUrl('/physicians')
    });
  }

  logout () {
    this.accountService.logout();
    this.router.navigateByUrl('/');
  }
}