using BusinessLayer.Interface;
using CommonLayer.RequestModel;
using ShoppingCartApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCartApp.Controllers
{
    public class HomeController : Controller
    {
      //  public HomeController() { }
        private readonly IProductsBusinessLayer _BusinessLayer;
        public HomeController(IProductsBusinessLayer BusinessLayerDI)
        {
            _BusinessLayer = BusinessLayerDI;
        }

       

        public ActionResult Index()
        {
           
            return View();
        }

        public ActionResult ViewProduct() {
            try
            {
              var Result = _BusinessLayer.GetAllProduct();
              return View(Result);
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        
        public ActionResult AddProducts(ProductInfo ProductDetails)
        {
            try
            {
                ProductRequestModel Data = new ProductRequestModel();
                Data.Name = "csdfcsd";
                Data.Image = "dfsdfsdfsd";
                Data.Price = 131;
                Data.Quantity = 12;
                var Result = _BusinessLayer.AddProduct(Data);
                return View();
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}