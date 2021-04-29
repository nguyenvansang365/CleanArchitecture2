using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.CQRS.ProductType.Command;
using CleanArchitecture.Application.DatabaseServices.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.CQRS.ProductType.CommandHandler
{
    public class CreateProductTypeCommandHandler : BaseProductTypeHandler, IRequestHandler<CreateProductTypeCommand, bool>
    {
        public CreateProductTypeCommandHandler(IProductTypeService productTypeDataService) : base(productTypeDataService)
        {
        }

        public async Task<bool> Handle(CreateProductTypeCommand createProductTypeCommandRequest, CancellationToken cancellationToken)
        {
            var result = await base._productTypeDataService.CreateProductType(createProductTypeCommandRequest);
            return result;
        }
    }
}
