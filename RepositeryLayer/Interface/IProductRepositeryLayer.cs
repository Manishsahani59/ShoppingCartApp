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
    }
}
