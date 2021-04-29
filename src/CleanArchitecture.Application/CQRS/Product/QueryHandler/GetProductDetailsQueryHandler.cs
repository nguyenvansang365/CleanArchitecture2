using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.CQRS.Product.Query;
using CleanArchitecture.Application.DatabaseServices.Interfaces;
using CleanArchitecture.Application.Models.Product;
using MediatR;

namespace CleanArchitecture.Application.CQRS.Product.QueryHandler
{
    public class GetProductDetailsQueryHandler: IRequestHandler<GetProductDetailsQuery, ProductDetailsResponseModel>
    {
        private readonly IProductService _productService;
        public GetProductDetailsQueryHandler(IProductService productTypeDataService)
        {
            _productService = productTypeDataService;
        }
        public async Task<ProductDetailsResponseModel> Handle(GetProductDetailsQuery request, CancellationToken cancellationToken)
        {
            var result = await _productService.GetProductDetails(request.ProductId);

            return result;
        }
    }
}
