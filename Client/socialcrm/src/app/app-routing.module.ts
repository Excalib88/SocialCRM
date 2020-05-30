import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';

const routes: Routes = [
  {
    path: 'leads',
    loadChildren: './modules/leads/leads.module/#LeadsModule'
  },
  {
    path: 'home',
    component: HomeComponent,
  },
  { 
    path: 'leads', 
    redirectTo: '/leads',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }