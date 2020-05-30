using BusinessLayer.Interface;
using CommonLayer.RequestModel;
using CommonLayer.ResponseModel;
using RepositeryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLayer.services
{
   public class ProductBusinessLayer : IProductsBusinessLayer
    {
        private readonly IProductRepositeryLayer _RepositeryLayer;
        public ProductBusinessLayer(IProductRepositeryLayer RepositeryLayerDI) {
            _RepositeryLayer = RepositeryLayerDI;
        }
        public ProductResponseModel AddProduct(ProductRequestModel ProductInfo)
        {
            try
            {
                if (ProductInfo != null) {
                   var Result= _RepositeryLayer.AddProduct(ProductInfo);
                    return Result;
                }
                return null;
            }
            catch (Exception e)
            {
                
                 throw new ApplicationException(e.Message);
            }
        }

        public int CountOrederedProduct()
        {
            try
            {
             int Result= _RepositeryLayer.CountOrederedProduct();
                if (Result != 0) {
                    return Result;
                }return 0;
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }
        }

        public bool DeleteProduct(int Id)
        {
            try
            {
                if (Id != 0) {
                    Boolean Result = _RepositeryLayer.DeleteProduct(Id);
                    if (Result)
                    {
                        return true ;
                    }
                    return false;
                }
                return false;
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
               var Result=_RepositeryLayer.OrderedProduct(OrderInfo);
                if (Result != null) {
                    return Result;
                }return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool RemoveProdcutOrder(int Id)
        {
            try
            {
               bool Result= _RepositeryLayer.RemoveProdcutOrder(Id);
                if (Result) {
                    return true;
                }return false;
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
               var Result= _RepositeryLayer.ViewOrderedProduct();
                if (Result != null) {
                    return Result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
             throw new ApplicationException(e.Message);
            }
        }

        List<ProductResponseModel> IProductsBusinessLayer.GetAllProduct()
        {
            try
            {
                var Result = _RepositeryLayer.GetAllProduct();
                if (Result!=null) {
                    return Result;
                }return null;
            }
            catch (Exception e)
            {

                throw new ApplicationException(e.Message);
            }        }
    }
}
