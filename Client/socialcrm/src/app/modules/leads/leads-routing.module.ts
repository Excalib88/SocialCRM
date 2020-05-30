import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LeadsComponent } from 'src/app/components/leads/leads.component';


const routes: Routes = [
  {
    path: 'leads',
    component: LeadsComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LeadsRoutingModule { }
