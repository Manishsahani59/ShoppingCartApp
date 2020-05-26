using CommonLayer.ModelDB;
using CommonLayer.RequestModel;
using CommonLayer.ResponseModel;
using RepositeryLayer.Context;
using RepositeryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppContext = RepositeryLayer.Context.AppContext;

namespace RepositeryLayer.services
{
   public class ProductRepositeryLayer : IProductRepositeryLayer
    {
        private readonly AppContext _context;

        public ProductRepositeryLayer(AppContext context)
        {
            _context = context;
        }

        public ProductResponseModel AddProduct(ProductRequestModel ProductDetails)
        {
            try
            {
                ProductDetails ProductInfo = new ProductDetails
                {
                    Name=ProductDetails.Name,
                    Price=ProductDetails.Price,
                    Image=ProductDetails.Image,
                    Quantity=ProductDetails.Quantity,
                    createAt=DateTime.Now,
                    ModefyAt=DateTime.Now
                };
                _context.Products.Add(ProductInfo);
                _context.SaveChanges();
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ProductResponseModel> GetAllProduct()
        {
            try
            {
                List<ProductResponseModel> Result = _context.Products.Select(products => new ProductResponseModel
                {
                 Id=products.Id,
                 Name= products.Name,
                 Price=products.Price,
                 Quantity=products.Quantity,
                 Image=products.Image,
                 CreatedAt=products.createAt,
                 ModefyAt=products.ModefyAt
                }).ToList();
                if (Result != null)
                    return Result;
                    return null;
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
        }
    }
}
