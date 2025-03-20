import { HomeComponent } from './components/auth/home/home.component';
import { Component } from '@angular/core';
import { Routes } from '@angular/router';
import { LoginComponent } from './components/auth/login/login.component';
import { RegisterComponent } from './components/auth/register/register.component';
import { PlacesComponent } from './components/auth/places/places.component';

export const routes: Routes = [
<<<<<<< Updated upstream
=======
<<<<<<< Updated upstream
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: '**', redirectTo: 'login' } // Default route
=======
  { path: 'auth/places', component: PlacesComponent },
>>>>>>> Stashed changes
  { path: 'auth/home', component: HomeComponent },
  { path: 'auth/login', component: LoginComponent },
  { path: 'auth/register', component: RegisterComponent },
  { path: '', redirectTo: 'auth/login', pathMatch: 'full' }, // Default route
  { path: '**', redirectTo: 'auth/login' } // Wildcard route
<<<<<<< Updated upstream
=======
>>>>>>> Stashed changes
>>>>>>> Stashed changes
];
