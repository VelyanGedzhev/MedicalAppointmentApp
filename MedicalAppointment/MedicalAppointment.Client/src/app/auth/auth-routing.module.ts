import { RouterModule, Routes } from "@angular/router";
import { AuthGuard } from "../core/guard/auth.guard";
import { PreventUnsavedEditGuard } from "../core/guard/prevent-unsaved-edit.guard";
import { ProfileEditComponent } from "./profile-edit/profile-edit.component";
import { RegisterComponent } from "./register/register.component";

const routes: Routes = [
    {
        path: 'register', component: RegisterComponent
    },
    {
        path: 'user/edit', component: ProfileEditComponent, canActivate: [AuthGuard], canDeactivate: [PreventUnsavedEditGuard]
    }

];
  
export const AuthRoutingModule  = RouterModule.forChild(routes);