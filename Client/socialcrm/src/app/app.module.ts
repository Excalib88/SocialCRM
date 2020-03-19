import { routing } from "./app.routing";
import { AppComponent } from "./app.component";
import { NgModule } from "@angular/core";
import { BrowserModule } from '@angular/platform-browser';


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    routing
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }