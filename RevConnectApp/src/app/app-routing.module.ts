import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { ChatroomComponent } from "./pages/chatroom/chatroom.component";
import { HomeComponent } from "./pages/home/home.component";
import { SettingsComponent } from "./pages/settings/settings.component";
import { UserProfileComponent } from "./pages/user-profile/user-profile.component";
import { PostfeedComponent } from "./pages/postfeed/postfeed.component";


const routes: Routes = [
    {path:'', component:HomeComponent},
    {path:'chatroom', component:ChatroomComponent},
    {path:'settings', component:SettingsComponent},
    {path:'user-profile', component:UserProfileComponent},
    {path:'postfeed', component:PostfeedComponent},

];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule {}



