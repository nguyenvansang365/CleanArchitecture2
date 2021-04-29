using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.CQRS.Product.Command;
using CleanArchitecture.Application.DatabaseServices.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.CQRS.Product.CommandHandler
{
    public class DeleteProductCommandHandler : BaseProductHandler,IRequestHandler<DeleteProductCommand, bool>
    {
        public DeleteProductCommandHandler(IProductService productDataService) : base(productDataService)
        {
        }
        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
           return await _productDataService.DeleteProduct(request.ProductID);
        }
    }
}
