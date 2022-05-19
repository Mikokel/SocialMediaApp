import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { ChatComponent } from './chat/chat.component';
import { LoginComponent } from './login/login.component';
import { LogoutComponent } from './logout/logout.component';
import { AuthModule } from '@auth0/auth0-angular';


@NgModule({
  declarations: [
    AppComponent,
    ChatComponent,
    LoginComponent,
    LogoutComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AuthModule.forRoot({
      domain: 'dev-vflsk82a.us.auth0.com',
      clientId: 'BylINEVHdMiuUeGtNS0VI0isIXgr9Zrm'
    }),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
