import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContactUsComponent } from 'src/app/web-site/contact-us/contact-us/contact-us.component';
import { CrezcoStoryComponent } from 'src/app/web-site/crezco-story/crezco-story/crezco-story.component';
import { GiveComponent } from 'src/app/web-site/give/give/give.component';
import { HomeComponent } from 'src/app/web-site/home/home.component';

import {
  LocationStrategy,
  Location,
  PathLocationStrategy,
} from '@angular/common';

const routes: Routes = [
  { path: 'contact-us', component: ContactUsComponent },
  { path: 'crezco-story', component: CrezcoStoryComponent },
  { path: 'give', component: GiveComponent },
  {
    path: 'auth',
    loadChildren: () => import('../app/web-site/auth/auth.module').then((m) => m.AuthModule),
  },
  {
    path: 'projects',
    loadChildren: () =>
      import('../app/web-site/projects/projects.module').then((m) => m.ProjectsModule),
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
