import {Product} from './product.model';

export class Order {
  id?: number;
  name?: string;
  amount: string;
  product: Product;
}
