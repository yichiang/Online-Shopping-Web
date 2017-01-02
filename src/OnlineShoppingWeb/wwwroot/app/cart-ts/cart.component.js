"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = require('angular2/core');
var router_1 = require('angular2/router');
var http_1 = require('angular2/http');
var cart_service_1 = require('./cart.service');
var CartComponent = (function () {
    function CartComponent(cartService) {
        this.cartService = cartService;
    }
    CartComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.cartService.getCartData().subscribe(function (data) { _this.data = data; _this.saveForLaters = data.saveForLaters; console.log(data); }, function (error) { return _this.errorMessage = error; });
    };
    CartComponent.prototype.toSaveForLater = function (productId) {
        console.log("Save");
        this.cartService.toSaveForLater(productId);
    };
    CartComponent = __decorate([
        core_1.Component({
            selector: "my-cart",
            templateUrl: 'app/cart-ts/cart.component.html',
            styleUrls: ['app/cart-ts/cart.component.css'],
            directives: [router_1.ROUTER_DIRECTIVES],
            providers: [
                http_1.HTTP_PROVIDERS, router_1.ROUTER_PROVIDERS, cart_service_1.CartService
            ]
        }), 
        __metadata('design:paramtypes', [cart_service_1.CartService])
    ], CartComponent);
    return CartComponent;
}());
exports.CartComponent = CartComponent;
