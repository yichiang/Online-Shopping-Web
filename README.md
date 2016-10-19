# _Online-Shopping-Web_
[Online Link](http://onlineshoppingweb.azurewebsites.net/)

#### By _**Yi Chiang**_

## Description

*  _I create an online shopping website for desktop view._

*  _My website has admin tool for manager to add new department and add new subDepartment.
For example, you can add Electronic department first and then add Phone or Laptop under Electronic_

## Function

* Checkout System- I implement [Stripe](https://stripe.com/) Api. For Demo purpose, I used [Checkout.js](https://stripe.com/docs/checkout) and custom form to process checkout.
* Email System - I built a simple send email under gamil. (It will be customized under checkout system.)
*  SendEmailService.cs
```
using MailKit.Net.Smtp;
using MimeKit;
using MailKit.Security;
using System.Threading.Tasks;

namespace OnlineShoppingWeb.Services
{
    public class SendEmailService
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Yi", "yi_chiang@outlook.com"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart("plain") { Text = message };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 465);
                client.AuthenticationMechanisms.Remove("XOAUTH2");

                // Note: only needed if the SMTP server requires authentication
                client.Authenticate("Your_Email_Address", "Your_Email_Password");
                client.Send(emailMessage);
                client.Disconnect(true);

            }
        }
    }
}
```
* File Upload - For Demo purpose, I built two different way of upload. The product image will be saved as "binary" or It will be saved on www.root/upload
1. Demo Purpose, I only put in ProductController -> CreateLaptop Action
```
[HttpPost]
       public async Task<IActionResult> CreateLaptop(ManagerProductViewModel viewModel)
       {
           viewModel.Laptop.SubDepartment = _DepartmentData.GetSubDepartmentById(viewModel.Laptop.SubDepartmentId);
           var usersfiles = HttpContext.Request.Form.Files;

           if (ModelState.IsValid)
           {
               _ProductData.AddNewProduct(viewModel.Laptop);

               foreach (var file in usersfiles)
               {
                   var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                   //Make sure File is Jpg
                   if (fileName.EndsWith(".jpg"))
                   {
                       //Save Files To WWWRoot/UpLoads Folder
                       var filePath = _env.ContentRootPath + "\\wwwroot\\" + fileName;
                       await file.CopyToAsync(new FileStream(Path.Combine(Path.Combine(_env.WebRootPath, "uploads"), file.FileName+ viewModel.Laptop.ProductId), FileMode.Create));

                       //Save Images to DataBase
                       byte[] m_Bytes = ReadToEnd(file.OpenReadStream());
                       ProductImage oneImage =new ProductImage { Content = m_Bytes, FileName = fileName, FileType=FileType.Photo, ProductId= viewModel.Laptop.ProductId,ContentType= file.ContentType};
                       _ProductData.SaveProductImages(oneImage);
                   }

               }

               return RedirectToAction("Index");

           }
```
## Instructions

## Support and contact details
  _Contact the authors if you have any questions or comments._

## Technologies Used
 _MVC, Stripe_

### License

* MIT License
* Copyright (c) [2016] Yi Chiang*
