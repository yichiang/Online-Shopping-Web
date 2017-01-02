import { Product } from './Product.model';
import { SaveForLater } from './SaveForLater.model';

export class Cart {
    public id: string;
    public products: Array<Product>;
    public saveForLaters: Array<SaveForLater>;
    public totalPrice: number;
    public productPrice: number;
    constructor() {
    }
}
