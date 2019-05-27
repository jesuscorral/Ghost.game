import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { GhostGameComponent } from './ghost-game/ghost-game.component';
import { Routes, RouterModule } from '@angular/router';
import { GhostService } from './services/ghost.service';

const appRoutes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: GhostGameComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    GhostGameComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(appRoutes),
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [
    GhostService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
