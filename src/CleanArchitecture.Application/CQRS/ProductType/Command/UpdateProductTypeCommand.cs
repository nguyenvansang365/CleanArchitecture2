using System;
using CleanArchitecture.Domain.Enums;
using MediatR;

namespace CleanArchitecture.Application.CQRS.ProductType.Command
{
    public class UpdateProductTypeCommand : IRequest<bool>
    {
        public Guid ProductTypeID { get; set; }
        public string ProductTypeKey { get; set; }
        public string ProductTypeName { get; set; }
        public RecordStatus RecordStatus { get; set; }
    }
}
