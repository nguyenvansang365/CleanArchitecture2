//using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Models.RequestModels;
using CleanArchitecture.Application.Models.ResponseModels;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.CQRS.ProductType.QueryHandler
{
    public class ProductTypeQueryHandler : IRequestHandler<ProductTypeQuery, ProductTypeQueryResponseModel>
    {
        public async Task<ProductTypeQueryResponseModel> Handle(ProductTypeQuery request, CancellationToken cancellationToken)
        {
            var productTypeQuery = new ProductTypeQueryResponseModel();
            // Your logic here
            productTypeQuery.ProductTypeName = "Test order";
            productTypeQuery.ProductTypeKey = "S500";
           
            return productTypeQuery;
        }
    }
}
