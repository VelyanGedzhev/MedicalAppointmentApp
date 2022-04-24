import { RouterModule, Routes } from "@angular/router";
import { NotFoundComponent } from "./not-found/not-found.component";
import { ServerErrorComponent } from "./server-error/server-error.component";

const routes: Routes = [
    {
        path: 'not-found', component: NotFoundComponent
    },
    {
        path: 'server-error', component: ServerErrorComponent
    }

];
  
export const SharedRoutingModule  = RouterModule.forChild(routes);