import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './core/home/home.component';

const routes: Routes = [
  {
    path: '', pathMatch: 'full', redirectTo: 'home'
  },
  {
    path: 'home', component: HomeComponent
  },
  {
    path: '**', pathMatch: 'full', component: HomeComponent
  }
];

export const AppRoutingModule = RouterModule.forRoot(routes);
