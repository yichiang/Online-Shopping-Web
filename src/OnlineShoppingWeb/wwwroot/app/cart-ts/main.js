"use strict";
var browser_1 = require('angular2/platform/browser');
var cart_component_1 = require('./cart.component');
var http_1 = require('angular2/http');
browser_1.bootstrap(cart_component_1.CartComponent, [http_1.HTTP_PROVIDERS]);
