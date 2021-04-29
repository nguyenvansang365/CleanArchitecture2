using CleanArchitecture.Application.DatabaseServices.Interfaces;

namespace CleanArchitecture.Application.CQRS.ProductType
{
    public class BaseProductTypeHandler
    {
        public readonly IProductTypeService _productTypeDataService;
        public BaseProductTypeHandler(IProductTypeService productTypeDataService)
        {
            _productTypeDataService = productTypeDataService;
        }
    }
}
