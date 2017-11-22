import { Routes, RouterModule } from '@angular/router';
import { LoginComponent   } from '../login/login.component';
import { Newcar } from '../newcar/newcar.component';
import { AppComponent } from '../shared/app.component';
import { ListComponent } from '../list/list.component';
import { CanActivateService } from '../../services/canActivate.service';
import { PageNotFoundComponent } from './../pageNotFound/PageNotFound.component';
import { UpdateCarComponent } from './../updatecar/update.component';

const appRoutes: Routes = [
    { path: 'login', component: LoginComponent },
   { path: 'list', component: ListComponent, canActivate: [CanActivateService] },
   { path: 'newcar', component: Newcar , canActivate: [CanActivateService]},
   { path: 'updatecar/:id', component: UpdateCarComponent },
   
   // otherwise redirect to home
   { path: '**', component: PageNotFoundComponent }
];

export const routing = RouterModule.forRoot(appRoutes);