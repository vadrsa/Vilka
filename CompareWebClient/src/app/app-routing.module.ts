import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './Components/home/home.component';
import { AuthGuard } from './Guards/AuthGuard';
import { LoginComponent } from './Components/Login/login.component';
import { RegionsComponent } from './Components/regions/regions.component';
 
 
const appRoutes: Routes = [
    { path: '', component: HomeComponent, canActivate: [AuthGuard] },
    { path: 'login', component: LoginComponent },
    { path: 'regions', component: RegionsComponent , canActivate: [AuthGuard] },
    
    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];
 
export const routing = RouterModule.forRoot(appRoutes);