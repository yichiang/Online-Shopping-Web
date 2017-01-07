# _Online-Shopping-Web_
[Online Link ---May be will shut down due to insufficient fund](http://onlineshoppingweb.azurewebsites.net/)

#### By _**Yi Chiang**_

## Description

*  _I create an online shopping website for desktop view._

*  _My website has admin tool for managers to add new department and add new subDepartment.
For example, you can add Electronic department first and then add Phone or Laptop under Electronic_

* add Angular2 on top of Razor view for cart views.


## Function

* Checkout System- I implement [Stripe](https://stripe.com/) Api. For Demo purpose, I used [Checkout.js](https://stripe.com/docs/checkout) and custom form to process checkout [JQuery payment] (https://github.com/stripe/jquery.payment).

* Email System - I built a simple send email under gamil. (It will be customized under checkout system.)

* File Upload - For Demo purpose, I built two different way of upload. The product image will be saved as "binary" or It will be saved on www.root/upload
1. Demo Purpose, I only put in ProductController -> CreateLaptop Action

## Instructions

## Support and contact details
  _Contact the authors if you have any questions or comments._

## Technologies Used
 _MVC, .NET core, Angular2, Email, Uploading file, Stripe_
 
## development
1. install (typescript for visual studio)[https://www.microsoft.com/en-us/download/details.aspx?id=48593]
2. install gulp `npm install -g gulp`
3. `typings install`
3. run `gulp` for building ts to javascript to `wwwroot/app/app-ts` and `wwwroot/app/cart-ts`.
4. build at `IIS express`
5. listen `localhost:49186`

## Note for running on Mac
_I did successfully run my project on Mac_
Note: I have gulp file to run task before publishing.
`npm install -g gulp` or `sudo npm install -g gulp`

1. Install .NET Core SDK `version: 1.1.0`
View details on https://www.microsoft.com/net/core#macos
2. Use online sql data server. You will need to run migration for database before using.
3. `dotnet restore` install all packages
4. `dotnet build` and `dotnet run` to run localhost.

### License

* MIT License
* Copyright (c) [2016] Yi Chiang*
