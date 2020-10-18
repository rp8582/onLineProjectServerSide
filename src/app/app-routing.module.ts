import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {EnteranceComponent} from './enterance/enterance.component'
import {LoginComponent} from './login/login.component'
import {CashierLoginComponent} from './cashier-login/cashier-login.component'
import {BusinessRegisterComponent} from './business-register/business-register.component'
import { HomeComponent } from './home/home.component';
import { AuthGuard } from '../app/auth.guard';
import {CashierDeskComponent} from './cashier-desk/cashier-desk.component'


const routes: Routes = [
  {path:'' , component : HomeComponent, canActivate:[AuthGuard]},
  {path:'enterance',component:EnteranceComponent},
  {path:'managerLogin',component:LoginComponent},
  {path:'cashierLogin',component:CashierLoginComponent},
  {path:'register',component:BusinessRegisterComponent},
  { path: 'cashier-desk/:id', component: CashierDeskComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
