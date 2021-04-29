using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.CQRS.ProductType.Query;
using MediatR;
using CleanArchitecture.Application.DatabaseServices.Interfaces;
using CleanArchitecture.Application.Models.ProductType;

namespace InstantPOS.Application.CQRS.ProductType.QueryHandler
{
    public class FetchProductTypeQueryHandler : IRequestHandler<FetchProductTypeQuery, IEnumerable<ProductTypeResponseModel>>
    {
        private readonly IProductTypeService _productTypeDataService;

        public FetchProductTypeQueryHandler(IProductTypeService productTypeDataService)
        {
            _productTypeDataService = productTypeDataService;
        }

        public async Task<IEnumerable<ProductTypeResponseModel>> Handle(FetchProductTypeQuery request, CancellationToken cancellationToken)
        {
            var result = await _productTypeDataService.FetchProductType();
            
            return result;
        }
    }
}
