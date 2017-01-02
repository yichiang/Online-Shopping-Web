import { Product } from './Product.model';

export class SaveForLater {
    public saveForLaterId: string;
    public productId: number;
    public userId: string;
    public product: Product;
    public saveForLaters: Array<Product>;
    constructor() {
    }
}
