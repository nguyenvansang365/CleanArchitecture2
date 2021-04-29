using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.CQRS.Product.Query;
using CleanArchitecture.Application.DatabaseServices.Interfaces;
using CleanArchitecture.Application.Models.Product;
using MediatR;

namespace CleanArchitecture.Application.CQRS.Product.QueryHandler
{
    public class FetchProductQueryHandler : BaseProductHandler, IRequestHandler<FetchProductQuery, IEnumerable<ProductResponseModel>>
    {
        public FetchProductQueryHandler(IProductService productDataService): base(productDataService)
        {
        }
        public async Task<IEnumerable<ProductResponseModel>> Handle(FetchProductQuery request, CancellationToken cancellationToken)
        {
            var result = await _productDataService.FetchProduct();

            return result;
        }
    }
}
