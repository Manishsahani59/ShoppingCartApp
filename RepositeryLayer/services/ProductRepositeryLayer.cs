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

        public int CountOrederedProduct()
        {
            try
            {
               int Result= _context.OrderedProduct.Count();
                if (Result != 0)
                {
                    return Result;
                }
                return 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteProduct(int Id)
        {
            try
            {
                ProductDetails ProductResponse = _context.Products.FirstOrDefault(linq=>linq.Id==Id);
                if (ProductResponse != null)
                {
                    _context.Products.Remove(ProductResponse);
                    _context.SaveChanges();
                    return true;
                }
                return false;

            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
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

        public ProductResponseModel OrderedProduct(OrderProductRequestModel OrderInfo)
        {
            try
            {
                ProductOrder Info = new ProductOrder
                {
                 ProductId=OrderInfo.ProductID,
                 isDeleted=OrderInfo.isDeleted,
                 OrderedDate=DateTime.Now,
                 ModefyDate=DateTime.Now,
                 };
                _context.OrderedProduct.Add(Info);
                _context.SaveChanges();
                return null;
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
        }

        public List<ProductResponseModel> ViewOrderedProduct()
        {
            try
            {
                List<ProductResponseModel> Products = new List<ProductResponseModel>();
                List<ProductOrder> Result = _context.OrderedProduct.ToList();

                if (Result != null)
                {
                    foreach (var data in Result)
                    {
                        ProductDetails OrderedProducts = _context.Products.FirstOrDefault(linq => linq.Id == data.ProductId);
                        if (OrderedProducts != null) {
                            ProductResponseModel OrderedProd = new ProductResponseModel
                            {
                                Id = OrderedProducts.Id,
                                Name = OrderedProducts.Name,
                                Quantity = OrderedProducts.Quantity,
                                Price = OrderedProducts.Price,
                                Image = OrderedProducts.Image,
                                CreatedAt = OrderedProducts.createAt,
                                ModefyAt = OrderedProducts.ModefyAt,
                            };
                            Products.Add(OrderedProd);

                        }

                    }
                }
                if (Products != null)
                    return Products;
                return null;

            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
        }

        public bool RemoveProdcutOrder(int Id) {
            try
            {
                 ProductOrder ProductResponse = _context.OrderedProduct.FirstOrDefault(linq => linq.ProductId == Id);
                if (ProductResponse != null)
                {
                    _context.OrderedProduct.Remove(ProductResponse);
                    _context.SaveChanges();
                    return true;
                }
                return false;

            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }

        }
     
    }
}
