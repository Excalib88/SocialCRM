import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LeadComponent } from 'src/app/components/lead/lead.component';
import { HomeComponent } from 'src/app/components/home/home.component';
 
const appRoutes: Routes = [
    { 
        path: '',
        redirectTo: '/home',
        pathMatch: 'full'
    },
    {
        path: 'home',
        component: HomeComponent
    },
    { 
        path: 'lead', 
        component: LeadComponent 
    }
];
@NgModule({
    imports: [RouterModule.forRoot(appRoutes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }