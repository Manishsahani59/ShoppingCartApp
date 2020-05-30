using CommonLayer.RequestModel;
using CommonLayer.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositeryLayer.Interface
{
    public interface IProductRepositeryLayer
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
