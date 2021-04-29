using CleanArchitecture.Domain.Enums;
using MediatR;

namespace CleanArchitecture.Application.CQRS.ProductType.Command
{
    public class CreateProductTypeCommand : IRequest<bool>
    {
        public string ProductTypeKey { get; set; }
        public string ProductTypeName { get; set; }
        public RecordStatus RecordStatus { get; set; }
    }
}
