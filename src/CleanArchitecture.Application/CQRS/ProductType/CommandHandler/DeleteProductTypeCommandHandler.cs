using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.CQRS.ProductType.Command;
using CleanArchitecture.Application.DatabaseServices.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.CQRS.ProductType.CommandHandler
{
    public class DeleteProductCommandHandler : BaseProductTypeHandler,IRequestHandler<DeleteProductTypeCommand, bool>
    {
        public DeleteProductCommandHandler(IProductTypeService productTypeDataService) : base(productTypeDataService)
        {
        }
        public async Task<bool> Handle(DeleteProductTypeCommand request, CancellationToken cancellationToken)
        {
           return await _productTypeDataService.DeleteProductType(request.ProductTypeID);
        }
    }
}
