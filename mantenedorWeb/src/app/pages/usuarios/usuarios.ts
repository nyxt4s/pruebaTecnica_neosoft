
import { Component } from '@angular/core';
import { IUsuario } from './models/userModel';
import { UserService } from '../../services/user.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-usuarios',
  imports: [CommonModule, FormsModule],
  standalone: true,
  template: `
              <h1>Usuarios</h1>
              <section>
                
              <form>
                  <label>Nombre:</label>
                  <input type="text" placeholder="Ingrese su Nombre" />
                  <label>Correo:</label>
                  <input type="text" placeholder="Ingrese su Correo" />
                  <label>Rol:</label>
                  <select>
                    <option value="admin">Administrador</option>
                    <option value="user">Usuario</option>
                    <option value="guest">Invitado</option>
                  </select>
                  <button class="primary" type="button">Search</button>
                </form>
                        <h3>Buscar Usuario por ID</h3>
                <form (ngSubmit)="getUsuarioById(usuarioId)">
                  <label for="usuarioId">ID del Usuario:</label>
                  <input type="number" id="usuarioId" [(ngModel)]="usuarioId" name="usuarioId" required />
                  <button type="submit" style="background-color: red">Buscar</button> 
                
                </form>

                <div *ngIf="usuarioEncontrado">
                  <h4>Usuario Encontrado:</h4>
                  <p>ID: {{ usuarioEncontrado.id }}</p>
                  <p>Nombre: {{ usuarioEncontrado.nombre }}</p>
                  <p>Email: {{ usuarioEncontrado.email }}</p>
                  <p>Rol: {{ usuarioEncontrado.rol?.nombre }}</p>
                </div>

                <h3>Usuarios</h3>
                  <table>
                    <thead>
                      <tr>
                        <th>Nombre</th>
                        <th>Correo</th>
                        <th>Rol</th>
                      </tr>
                  </thead>
                    <tbody>
                      <tr *ngFor="let user of users">
                        <td>{{ user.nombre }}</td>
                        <td>{{ user.email }}</td>
                        <td>{{ user.rol?.nombre }}</td>
                      </tr>
                    </tbody>
                  </table>

        
              </section>
                `,
  styleUrl: './usuarios.css'
})
export class Usuarios {
    users: IUsuario[] = [];
    usuarioEncontrado: IUsuario | null = null;
    usuarioId: number | null = null;

    constructor(private userService: UserService) { {
        this.userService.getUsuarios().subscribe((data: IUsuario[]) => {
            this.users = data;
        });
    } }

    ngOnInit() {
        this.userService.getUsuarios().subscribe((data: IUsuario[]) => {
            this.users = data;
        });
    }

    getUsuarioById(id: number | null) {
  if (id === null) return;
  this.userService.getUsuarioById(id).subscribe((data: IUsuario) => {
    this.usuarioEncontrado = data;
  });
}

   
}
