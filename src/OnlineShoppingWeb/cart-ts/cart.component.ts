﻿import { Component, Input, OnInit } from 'angular2/core';
import { RouteConfig, ROUTER_DIRECTIVES, ROUTER_PROVIDERS } from 'angular2/router';
import { Product } from './Product.model';
import { Cart } from './Cart.model';
import { HTTP_PROVIDERS } from 'angular2/http';
import { SaveForLater } from './SaveForLater.model';
import { CartService } from './cart.service';



@Component({
    selector: "my-cart",
    templateUrl: 'app/cart-ts/cart.component.html',
    styleUrls: ['app/cart-ts/cart.component.css'],
    directives: [ROUTER_DIRECTIVES],
    providers: [
        HTTP_PROVIDERS, ROUTER_PROVIDERS, CartService
    ]
})

export class CartComponent {
    data: Cart;
    saveForLaters: Array<SaveForLater>;
    errorMessage: string;
    constructor(private cartService: CartService) { }
    ngOnInit(): void {
        this.cartService.getCartData().subscribe(data => { this.data = data; this.saveForLaters = data.saveForLaters; console.log("Get", data); },
            error => this.errorMessage = <any>error);
    }
    toSaveForLater(productId: number) {
        console.log("Save");
        this.cartService.toSaveForLater(productId)
            .subscribe(data => { this.data = data; console.log("Post", data);},
                        error => this.errorMessage = <any>error);
    }
    deleteCartItem(productId: number) {
        this.cartService.deleteCartItem(productId)
            .subscribe(data => {
                if (data.success) { this.data.products = this.data.products.filter(x => x.productId != productId) }
            },
            error => this.errorMessage = <any>error);
    }
}