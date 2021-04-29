using System;
using MediatR;

namespace CleanArchitecture.Application.CQRS.ProductType.Command
{
    public class DeleteProductTypeCommand : IRequest<bool>
    {
        public Guid ProductTypeID { get; set; }
    }
}
