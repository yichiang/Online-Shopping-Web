﻿import { Component, Input, OnInit } from 'angular2/core';
import { RouteConfig, ROUTER_DIRECTIVES, ROUTER_PROVIDERS } from 'angular2/router';
import { Product } from './Product.model';
import { Cart } from './Cart.model';
import { HTTP_PROVIDERS } from 'angular2/http';

import { CartService } from './cart.service';



@Component({
    selector: "my-cart",
    templateUrl: 'app/cart-ts/cart.component.html',
    directives: [ROUTER_DIRECTIVES],
    providers: [
        HTTP_PROVIDERS, ROUTER_PROVIDERS, CartService
    ]
})

export class CartComponent {
    data: Array<Product>;
    errorMessage: string;
    constructor(private cartService: CartService) { }
    ngOnInit(): void {
        this.cartService.getCartData().subscribe(data => { this.data = data.products; console.log(data); },
            error => this.errorMessage = <any>error);
    }
}