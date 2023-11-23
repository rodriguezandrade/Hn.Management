import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContactUsComponent } from 'src/contact-us/contact-us/contact-us.component';
import { CrezcoStoryComponent } from 'src/crezco-story/crezco-story/crezco-story.component';
import { GiveComponent } from 'src/give/give/give.component';
import { HomeComponent } from 'src/home/home.component';
import { UserRegistrationComponent } from './components/users/user-registration/user-registration.component';

import {
  LocationStrategy,
  Location,
  PathLocationStrategy,
} from '@angular/common';

const routes: Routes = [
  { path: 'contact-us', component: ContactUsComponent },
  { path: 'crezco-story', component: CrezcoStoryComponent },
  { path: 'give', component: GiveComponent },
  { path: 'user-registration', component: UserRegistrationComponent },
  {
    path: 'auth',
    loadChildren: () => import('../auth/auth.module').then((m) => m.AuthModule),
  },
  {
    path: 'projects',
    loadChildren: () =>
      import('../projects/projects.module').then((m) => m.ProjectsModule),
  },
  { path: '', component: HomeComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {scrollPositionRestoration: 'top'})],
  exports: [RouterModule],
  providers: [
    Location,
    { provide: LocationStrategy, useClass: PathLocationStrategy },
  ],
})
export class AppRoutingModule {}
