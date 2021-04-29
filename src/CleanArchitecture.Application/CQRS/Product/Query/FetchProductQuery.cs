using System;
using System.Collections.Generic;
using CleanArchitecture.Application.Models.Product;
using MediatR;

namespace CleanArchitecture.Application.CQRS.Product.Query
{
    public class FetchProductQuery : IRequest<IEnumerable<ProductResponseModel>>
    {

    }
}
