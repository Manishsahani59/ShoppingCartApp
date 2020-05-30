using CommonLayer.RequestModel;
using CommonLayer.ResponseModel;
using System.Collections.Generic;

namespace BusinessLayer.Interface
{
   public interface IProductsBusinessLayer
    {
        ProductResponseModel AddProduct(ProductRequestModel ProductInfo);
        List<ProductResponseModel> GetAllProduct();

        bool DeleteProduct(int Id);
        int CountOrederedProduct();
        ProductResponseModel OrderedProduct(OrderProductRequestModel OrderInfo);

        List<ProductResponseModel> ViewOrderedProduct();
        bool RemoveProdcutOrder(int Id);


    }
}
