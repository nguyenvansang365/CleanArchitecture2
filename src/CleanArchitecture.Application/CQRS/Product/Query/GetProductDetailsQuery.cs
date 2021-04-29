using System;
using CleanArchitecture.Application.Models.Product;
using MediatR;

namespace CleanArchitecture.Application.CQRS.Product.Query
{
    public class GetProductDetailsQuery : IRequest<ProductDetailsResponseModel>
    {
        public Guid ProductId { get; set; }
    }
}
