using CleanArchitecture.Domain.Entites;
using CleanArchitecture.Domain.Enums;
using MediatR;
using System;
using CleanArchitecture.Application.Models.ResponseModels;

namespace CleanArchitecture.Application.Models.RequestModels
{
    public class ProductQuery : IRequest<ProductQueryResponseModel>
    {
        public Guid ProductID { get; set; }
    }
}
