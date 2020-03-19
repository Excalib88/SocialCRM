import { Routes, RouterModule } from '@angular/router';
import { LeadsComponent } from './leads/leads.component';

const appRoutes: Routes = [
    { path: 'lead', component: LeadsComponent }
];

export const routing = RouterModule.forRoot(appRoutes);