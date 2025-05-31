import { Rol } from "../../rol/models/rol";


export interface IUsuario {
  id: number;
  nombre: string;
  email: string;
  rol?: Rol; // opcional si el API devuelve el objeto Rol completo
}
