import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from 'src/app/core/guard/auth.guard';
import { AppointmentDetailsComponent } from './appointment-details/appointment-details.component';
import { AppointmentsListComponent } from './appointments-list/appointments-list.component';

const routes: Routes = [
  {
      path: 'appointments', component: AppointmentsListComponent, canActivate: [AuthGuard]
  },
  {
      path: 'appointments/:id', component: AppointmentDetailsComponent
  }
];

export const AppointmentRoutingModule = RouterModule.forChild(routes);