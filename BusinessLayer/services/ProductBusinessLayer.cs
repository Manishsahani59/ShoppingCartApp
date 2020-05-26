using BusinessLayer.Interface;
using CommonLayer.RequestModel;
using CommonLayer.ResponseModel;
using RepositeryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
