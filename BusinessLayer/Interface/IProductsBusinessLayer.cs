using CommonLayer.RequestModel;
using CommonLayer.ResponseModel;
using System.Collections.Generic;

namespace BusinessLayer.Interface
{
   public interface IProductsBusinessLayer
    {
        ProductResponseModel AddProduct(ProductRequestModel ProductInfo);
        List<ProductResponseModel> GetAllProduct();
    }
}
