import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Usuarios } from './pages/usuarios/usuarios';

@Component({
  selector: 'app-root',
  imports: [ Usuarios],
  template: `<main>
                
                    <app-usuarios></app-usuarios>
             </main>
              `,
  styleUrl: './app.css' 
})
export class App {
   title = 'Home';
}
