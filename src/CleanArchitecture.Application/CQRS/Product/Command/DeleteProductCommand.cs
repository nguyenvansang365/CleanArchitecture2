using System;
using MediatR;

namespace CleanArchitecture.Application.CQRS.Product.Command
{
    public class DeleteProductCommand : IRequest<bool>
    {
        public Guid ProductID { get; set; }
    }
}
