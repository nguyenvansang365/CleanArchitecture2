using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.CQRS.ProductType.Query;
using CleanArchitecture.Application.DatabaseServices.Interfaces;
using CleanArchitecture.Application.Models.ProductType;
using MediatR;

namespace CleanArchitecture.Application.CQRS.ProductType.QueryHandler
{
    public class GetProductDetailsQueryHandler: IRequestHandler<GetProductTypeDetailsQuery, ProductTypeDetailsResponseModel>
    {
        private readonly IProductTypeService _productTypeDataService;
        public GetProductDetailsQueryHandler(IProductTypeService productTypeDataService)
        {
            _productTypeDataService = productTypeDataService;
        }
        public async Task<ProductTypeDetailsResponseModel> Handle(GetProductTypeDetailsQuery request, CancellationToken cancellationToken)
        {
            var result = await _productTypeDataService.GetProductTypeDetails(request.ProductTypeId);

            return result;
        }
    }
}
