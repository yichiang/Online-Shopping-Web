﻿
import { Http, Response, Headers, RequestOptions  } from 'angular2/http';
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
        return this._http.get('/api/cart')
            .map((response: Response) => <Cart>response.json())
            .catch(this.handleError);
    }

    toSaveForLater(productId: number): Observable<Cart> {
        //let body = JSON.stringify({"productId": productId});
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });
        console.log("Try to save", productId);
        console.log("Post", '/api/saveForLater/' + productId )
        return this._http.post('http://localhost:49186/api/saveForLater/' + productId, null, options)
            .map((response: Response) => { <Cart>response.json(); console.log("response", response); })
            //.do(console.log("Try to save", productId))
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