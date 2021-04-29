using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.CQRS.ProductType.Command;
using CleanArchitecture.Application.DatabaseServices.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.CQRS.ProductType.CommandHandler
{
    public class UpdateProductTypeCommandHandler : BaseProductTypeHandler,IRequestHandler<UpdateProductTypeCommand, bool>
    {
        public UpdateProductTypeCommandHandler(IProductTypeService productTypeDataService) : base(productTypeDataService)
        {
        }
        public async Task<bool> Handle(UpdateProductTypeCommand updateProductTypeCommandRequest, CancellationToken cancellationToken)
        {
            var result = await base._productTypeDataService.UpdateProductType(updateProductTypeCommandRequest);
            return result;
        }
    }
}
