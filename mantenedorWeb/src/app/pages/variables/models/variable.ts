
export type TipoVariable = 'texto' | 'numérico' | 'booleano';

export interface Variable {
  id: number;
  nombre: string;
  valor: string;
  tipo: TipoVariable;
}