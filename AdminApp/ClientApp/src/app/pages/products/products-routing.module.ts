import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {IndexComponent} from './index/index.component';
import {EditComponent} from './edit/edit.component';
import {CreateComponent} from './create/create.component';


const routes: Routes = [
  { path: '',   component: IndexComponent },
  { path: ':id/aanpassen',   component: EditComponent },
  { path: 'aanmaken',   component: CreateComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProductsRoutingModule { }
