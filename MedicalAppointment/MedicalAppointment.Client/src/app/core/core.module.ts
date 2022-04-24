import { RouterModule } from '@angular/router';
import { ModuleWithProviders, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './header/header.component';
import { FormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS } from '@angular/common/http';

import { AccountService } from './services/account.service';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { HomeComponent } from '../shared/home/home.component';
import { AuthModule } from '../auth/auth.module';
import { ToastrModule } from 'ngx-toastr';
import { ErrorInterceptor } from './interceptors/error.interceptor';



@NgModule({
  declarations: [
    HeaderComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    BsDropdownModule.forRoot(),
    AuthModule,
    RouterModule,
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right'
    })
  ],
  providers: [],
  exports: [
    HeaderComponent,
    ToastrModule,
    BsDropdownModule
  ]
})

export class CoreModule {
  static forRoot(): ModuleWithProviders<CoreModule> {
    return {
      ngModule: CoreModule,
      providers: [ 
        AccountService,
        { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true}
      ]
    } 
  }
 }
