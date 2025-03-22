import { HomeComponent } from './components/auth/home/home.component';
import { Component } from '@angular/core';
import { Routes } from '@angular/router';
import { LoginComponent } from './components/auth/login/login.component';
import { RegisterComponent } from './components/auth/register/register.component';
import { PlacesComponent } from './components/auth/places/places.component';
import { ReviewsComponent } from './components/reviews/reviews.component';
// import { ReviewScreenComponent } from './pages/review-screen/review-screen.component';

export const routes: Routes = [


  { path: 'auth/places', component: PlacesComponent },
  { path: 'auth/home', component: HomeComponent },
  { path: 'auth/login', component: LoginComponent },
  { path: 'auth/register', component: RegisterComponent },
  { path: 'reviews/:type/:itemId', component: ReviewsComponent },
  // { path: 'reviews', component: ReviewScreenComponent },
  { path: '', redirectTo: 'auth/login', pathMatch: 'full' }, // Default route
  { path: '**', redirectTo: 'auth/login' } // Wildcard route

];
