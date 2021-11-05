import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';

import { HomeComponent } from './home/home.component';
import { CharaAdderComponent } from './chara-adder/chara-adder.component';
import { CharacterDetailComponent } from './character-detail/character-detail.component';
import { CharaVisualRefComponent } from './chara-visual-ref/chara-visual-ref.component';




@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    CharaAdderComponent,
    CharacterDetailComponent,
    CharaVisualRefComponent

  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' }

    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
