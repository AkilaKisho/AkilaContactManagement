import { Component } from '@angular/core';
//import { RouterOutlet } from '@angular/router';
import { ContactComponent } from './components/contact/contact.component'; 

@Component({
  selector: 'app-root',
 // imports: [RouterOutlet],
 standalone: true, 
 imports: [ContactComponent], 
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent {
  title = 'ContactManager';
}
