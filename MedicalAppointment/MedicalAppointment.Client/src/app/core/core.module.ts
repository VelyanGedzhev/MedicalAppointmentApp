import { RouterModule } from '@angular/router';
import { ModuleWithProviders, NgModule } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { HeaderComponent } from './header/header.component';
import { FormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS } from '@angular/common/http';

import { AccountService } from './services/account.service';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { AuthModule } from '../auth/auth.module';
import { ToastrModule } from 'ngx-toastr';
import { ErrorInterceptor } from './interceptors/error.interceptor';
import { PhysicianService } from './services/physician.service';
import { JwtInterceptor } from './interceptors/jwt.interceptor';
import { AppointmentService } from './services/appointment.service';
import { FooterComponent } from './footer/footer.component';



@NgModule({
  declarations: [
    HeaderComponent,
    FooterComponent,
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
    BsDropdownModule,
    FooterComponent
  ]
})

export class CoreModule {
  static forRoot(): ModuleWithProviders<CoreModule> {
    return {
      ngModule: CoreModule,
      providers: [ 
        AccountService,
        PhysicianService,
        AppointmentService,
        DatePipe,
        { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true},
        { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true}
      ]
    } 
  }
 }
