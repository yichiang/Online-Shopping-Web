import { Product } from './Product.model';

export class Cart {
    public id: string;
    public products: Array<Product>;
    public totalPrice: number;
    public productPrice: number;
    constructor() {
    }
}
