﻿import { Component, Input, ElementRef } from 'angular2/core';
import { RouteConfig, ROUTER_DIRECTIVES, ROUTER_PROVIDERS } from 'angular2/router';


@Component({
    selector: "my-cart",
    template: `Good !!****`,
    directives: [ROUTER_DIRECTIVES],
    providers: [
        ROUTER_PROVIDERS
    ]
})

export class CartComponent {
    constructor(private elementRef: ElementRef) { }
}