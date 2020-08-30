import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ProductDetailsComponent } from './shop/product-details/product-details.component';
import { TextErrorComponent } from './core/text-error/text-error.component';
import { NotFoundComponent } from './core/not-found/not-found.component';
import { ServerErrorComponent } from './core/server-error/server-error.component';
import {AuthGuard} from './core/guards/auth.guard';

const routes: Routes = [
  { path: '', component: HomeComponent, data: { breadcrumb: 'Home' } },
  {
    path: 'test-error',
    component: TextErrorComponent,
    data: { breadcrumb: 'Test Errors' },
  },
  {
    path: 'server-error',
    component: ServerErrorComponent,
    data: { breadcrumb: 'Server Errors' },
  },
  {
    path: 'not-found',
    component: NotFoundComponent,
    data: { breadcrumb: 'Not Found' },
  },
  {
    path: 'shop',
    loadChildren: () =>
      import('./shop/shop.module').then((mod) => mod.ShopModule),
    data: { breadcrumb: 'Shop' },
  }, // dont want to load shop component unless requested for. Lazy loading implemented
  // { path: 'shop/:id', component: ProductDetailsComponent },,
  {
    path: 'basket',
    loadChildren: () =>
      import('./basket/basket.module').then((mod) => mod.BasketModule),
    data: { breadcrumb: 'Basket' },
  },
  {
    path: 'checkout',
    canActivate: [AuthGuard],
    loadChildren: () =>
      import('./checkout/checkout.module').then((mod) => mod.CheckoutModule),
    data: { breadcrumb: 'Checkout' },
  },
  {
    path: 'account',
    canActivate: [AuthGuard],
    loadChildren: () =>
      import('./account/account.module').then((mod) => mod.AccountModule),
    data: { breadcrumb: {skip: true} },
  },
  {
    path: 'orders',
    canActivate: [AuthGuard],
    loadChildren: () =>
      import('./order/order.module').then((mod) => mod.OrderModule),
    data: { breadcrumb: 'Orders' },
  },
  { path: '**', redirectTo: 'not-found', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
