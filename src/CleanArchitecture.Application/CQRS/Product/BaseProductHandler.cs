using CleanArchitecture.Application.DatabaseServices.Interfaces;

namespace CleanArchitecture.Application.CQRS.Product
{
    public class BaseProductHandler
    {
        public readonly IProductService _productDataService;
        public BaseProductHandler(IProductService productDataService)
        {
            _productDataService = productDataService;
        }
    }
}
