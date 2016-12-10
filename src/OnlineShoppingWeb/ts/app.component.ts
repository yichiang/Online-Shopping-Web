﻿import { Component } from 'angular2/core';
import { RouteConfig, ROUTER_DIRECTIVES, ROUTER_PROVIDERS } from 'angular2/router';


@Component({
    selector: "my-app",
    template: "Hi",
    directives: [ROUTER_DIRECTIVES],
    providers: [
        ROUTER_PROVIDERS
    ]
})
//@RouteConfig([
//    { path: "/events", name: "EventList", component: EventListComponent, useAsDefault: true }
//])
export class AppComponent { }