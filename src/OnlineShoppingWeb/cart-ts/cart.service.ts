
import { Http, Response } from 'angular2/http';
import { Observable } from 'rxjs/Observable';
//import 'rxjs/add/operator/map';
import 'rxjs/Rx';
import { Injectable } from 'angular2/core';
import { Product } from './Product.model';
import { Cart } from './Cart.model';

@Injectable()
export class CartService {
    constructor(private _http: Http) { }
    getCartData(): Observable<Cart> {
        return this._http.get('http://localhost:49186/api/cart').map((response: Response) => <Cart>response.json())
            .catch(this.handleError);
    }
    private handleError(error: Response) {
        return Observable.throw(error.json().error || 'Serve error');
    }
    private extractData(res: Response) {
        let body = res.json();
        return body.data || {};
    }

   
}