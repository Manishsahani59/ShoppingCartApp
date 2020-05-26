using BusinessLayer.Interface;
using CommonLayer.RequestModel;
using CommonLayer.ResponseModel;
using ShoppingCartApp.Models;
using System;
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
                    ProductRequestModel Data = new ProductRequestModel()
                    {
                        Name = ProductDetails.Name,
                        Image = ProductDetails.Image,
                        Price = ProductDetails.Price,
                        Quantity = ProductDetails.Quantity
                    };
                    var Result = BusinessLayer.AddProduct(Data);
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
                return View(Result);
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
        }
    }
}