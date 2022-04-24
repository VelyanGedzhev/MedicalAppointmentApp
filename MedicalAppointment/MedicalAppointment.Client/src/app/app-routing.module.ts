import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './shared/home/home.component';
import { NotFoundComponent } from './shared/not-found/not-found.component';

const routes: Routes = [
  {
    path: '', pathMatch: 'full', redirectTo: 'home'
  },
  {
    path: 'home', component: HomeComponent
  },
  {
    path: '**', pathMatch: 'full', component: NotFoundComponent
  }
];

export const AppRoutingModule = RouterModule.forRoot(routes);
