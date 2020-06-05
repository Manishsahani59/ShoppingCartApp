using BusinessLayer.Interface;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using CommonLayer.RequestModel;
using Microsoft.Reporting.WebForms;
using ShoppingCartApp.Models;
using ShoppingCartApp.Reports;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

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
                   HttpPostedFileBase productImage = ProductDetails.Image;
                    string productImagePath = UploadImageToCloudinery(productImage);
                  
                   
                    ProductRequestModel Data = new ProductRequestModel()
                    {
                        Name = ProductDetails.Name,
                        Image = productImagePath,
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
        public string UploadImageToCloudinery(HttpPostedFileBase productImage) {
            try
            {
                Account account = new Account(
                 "dmxhysf6r",
                 "995237421458962",
                 "1DfOBtSkCtJvcRvkOHISNNfum8k"
                );
                //       var Account = new Account(ConfigurationManager.AppSettings["Cloud_Name"],
                //ConfigurationManager.AppSettings["Api_Key"], ConfigurationManager.AppSettings["Api_Secret"]);
                Cloudinary cloudinary = new Cloudinary(account);
                var uploadImage = new ImageUploadParams
                {
                    File = new FileDescription(productImage.FileName, productImage.InputStream),
                    Folder="ShoppingCartApp"
                };
                var Result = cloudinary.Upload(uploadImage);
                return Result.SecureUri.AbsoluteUri;
            }
            
            catch (Exception e) {
                throw new ApplicationException(e.Message);
            }
        }

        [HttpDelete]
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

        public ActionResult Checkout(checkoutData info) {
            try
            {
                return View();
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message); 
            }
        }


            ProductDataSet ds = new ProductDataSet();
            public ActionResult ProductReport()
            {
                ReportViewer reportViewer = new ReportViewer();
                reportViewer.ProcessingMode = ProcessingMode.Local;
                reportViewer.SizeToReportContent = true;
                reportViewer.Width = Unit.Percentage(100);
                reportViewer.Height = Unit.Percentage(100);

                var connectionString = ConfigurationManager.ConnectionStrings["ShoppingcartApplication"].ConnectionString;


                SqlConnection conx = new SqlConnection(connectionString); SqlDataAdapter adp = new SqlDataAdapter("SELECT * FROM Products", conx);

                adp.Fill(ds, ds.Products.TableName);

                reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Reports\ProductReport.rdlc";
                reportViewer.LocalReport.DataSources.Add(new ReportDataSource("ProductDataSet", ds.Tables[0]));
                ViewBag.ReportViewer = reportViewer;
                return View();
            }
        }
    }

