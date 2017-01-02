import { Product } from './Product.model';

export class SaveForLater {
    public saveForLaterId: string;
    public productId: number;
    public userId: string;
    public proudct: Product;
    public saveForLaters: Array<Product>;
    constructor() {
    }
}
