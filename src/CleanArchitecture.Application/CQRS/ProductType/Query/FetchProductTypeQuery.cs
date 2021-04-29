using System.Collections.Generic;
using CleanArchitecture.Application.Models.ProductType;
using MediatR;

namespace CleanArchitecture.Application.CQRS.ProductType.Query
{
    public class FetchProductTypeQuery : IRequest<IEnumerable<ProductTypeResponseModel>>
    {
      
    }
}
