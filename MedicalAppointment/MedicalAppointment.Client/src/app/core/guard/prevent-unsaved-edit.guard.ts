import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanDeactivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { ProfileEditComponent } from 'src/app/auth/profile-edit/profile-edit.component';

@Injectable({
  providedIn: 'root'
})
export class PreventUnsavedEditGuard implements CanDeactivate<unknown> {
  canDeactivate(component: ProfileEditComponent): boolean {
    if (component.editForm.dirty) {
      return confirm('Are you sure you want to leave without saving your changes?');
    }
    return true;
  }
  
}
