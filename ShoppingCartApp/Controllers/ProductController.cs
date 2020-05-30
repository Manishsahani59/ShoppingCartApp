using BusinessLayer.Interface;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using CommonLayer.RequestModel;
using CommonLayer.ResponseModel;
using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using ShoppingCartApp.Models;
using System;
using System.Configuration;
using System.Drawing;
using System.Reflection.Emit;
using System.Web.Mvc;

namespace ShoppingCartApp.Controllers
{
    public class ProductController : Controller
    {
        private IProductsBusinessLayer BusinessLayer;
        public ProductController(IProductsBusinessLayer BusinessLayerDI) {
            BusinessLayer = BusinessLayerDI;
        }

        public ActionResult AddProducts(ProductInfo ProductDetails)
        {
            try
            {
                if (ModelState.IsValid) {
                  //  string cloudineryPath=UploadImageToCloudinery(ProductDetails.Image);
                   
                    ProductRequestModel Data = new ProductRequestModel()
                    {
                        Name = ProductDetails.Name,
                        Image = ProductDetails.Image,
                        Price = ProductDetails.Price,
                        Quantity = ProductDetails.Quantity
                    };
                    var Result = BusinessLayer.AddProduct(Data);
                    return RedirectToAction("ViewProduct", "Product");
                }
                return View();
                
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
        }

        public ActionResult ViewProduct()
        {
            try
            {
                var Result = BusinessLayer.GetAllProduct();
                Result.Reverse();
                return View(Result);
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
        }
        public string UploadImageToCloudinery(string ImagePath) {
            try
            {
                Account Account = new Account(
                 "dmxhysf6r",
                 "995237421458962",
                 "1DfOBtSkCtJvcRvkOHISNNfum8k"
                );
                Cloudinary cloudinary = new Cloudinary(Account);

                var imageUpload = new ImageUploadParams
                {
                    File = new FileDescription(ImagePath),
                    Folder = "ShoppingCartApp"
                };

                var uploadImage = cloudinary.Upload(imageUpload);

                return uploadImage.SecureUri.AbsoluteUri;
            }
            catch (Exception e) {
                throw new ApplicationException(e.Message);
            }
        }

        public ActionResult DeleteProduct(int Id)
        {
            try
            {
             var Result= BusinessLayer.DeleteProduct(Id);
                return View(Result);
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }       
        }
        
        public ActionResult OrderedProduct(int Id) {
            try
            {
                OrderProductRequestModel Info = new OrderProductRequestModel
                {
                    ProductID=Id,
                };
                var Result=  BusinessLayer.OrderedProduct(Info);
                return RedirectToAction("ViewProduct", "Product");

            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }    
        }

        public int CountOrderedProduct() {
            try
            {
               int Result=BusinessLayer.CountOrederedProduct();
                return Result;
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
        }

        public ActionResult ViewOrderedProducts() {
            try
            {
              var Result= BusinessLayer.ViewOrderedProduct();
                return View(Result);
            }
            catch (Exception e) {
                throw new ApplicationException(e.Message);
            }
        }

        public ActionResult RemoveProdcutOrder(int Id) {
            try
            {
              var Result=  BusinessLayer.RemoveProdcutOrder(Id);
                return RedirectToAction("ViewOrderedProducts", "Product");
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
        }

        public ActionResult Checkout() {
            try
            {
                return View();
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message); 
            }
        }

    }
}