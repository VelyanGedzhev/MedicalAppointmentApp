import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from 'src/app/core/guard/auth.guard';
import { PhysicianDetailsComponent } from './physician-details/physician-details.component';
import { PhysiciansListComponent } from './physicians-list/physicians-list.component';

const routes: Routes = [
  {
      path: 'physicians', component: PhysiciansListComponent
  },
  {
      path: 'physicians/:id', component: PhysicianDetailsComponent,  canActivate: [AuthGuard]
  }
];

export const PhysiciansRoutingModule = RouterModule.forChild(routes);