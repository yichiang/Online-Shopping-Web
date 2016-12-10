﻿import { Component, Input, ElementRef } from 'angular2/core';
import { RouteConfig, ROUTER_DIRECTIVES, ROUTER_PROVIDERS } from 'angular2/router';


@Component({
    selector: "my-cart",
    template: `
    cart components !!!!!!!!!!!!!!!!!!!
    <ul>
        <li *ngFor="#item of products; #i = index">
            {{item.name}} {{i}} !!!
        </li>
    </ul>
    {{products}}!!!!`,
    directives: [ROUTER_DIRECTIVES],
    providers: [
        ROUTER_PROVIDERS
    ]
})
//@RouteConfig([
//    { path: "/events", name: "EventList", component: EventListComponent, useAsDefault: true }
//])
export class CartComponent {
    constructor(private elementRef: ElementRef) { }

    products: any = this.elementRef.nativeElement.getAttribute('products');


}