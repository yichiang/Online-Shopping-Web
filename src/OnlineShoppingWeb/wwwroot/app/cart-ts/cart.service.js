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
var http_1 = require('angular2/http');
var Observable_1 = require('rxjs/Observable');
//import 'rxjs/add/operator/map';
require('rxjs/Rx');
var core_1 = require('angular2/core');
var CartService = (function () {
    function CartService(_http) {
        this._http = _http;
    }
    CartService.prototype.getCartData = function () {
        return this._http.get('http://localhost:49186/api/cart').map(function (response) { return response.json(); })
            .catch(this.handleError);
    };
    CartService.prototype.handleError = function (error) {
        return Observable_1.Observable.throw(error.json().error || 'Serve error');
    };
    CartService.prototype.extractData = function (res) {
        var body = res.json();
        return body.data || {};
    };
    CartService = __decorate([
        core_1.Injectable(), 
        __metadata('design:paramtypes', [http_1.Http])
    ], CartService);
    return CartService;
}());
exports.CartService = CartService;
