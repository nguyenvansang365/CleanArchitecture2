using System;
using CleanArchitecture.Application.Models.ProductType;
using MediatR;

namespace CleanArchitecture.Application.CQRS.ProductType.Query
{
    public class GetProductTypeDetailsQuery : IRequest<ProductTypeDetailsResponseModel>
    {
        public Guid ProductTypeId { get; set; }
    }
}
