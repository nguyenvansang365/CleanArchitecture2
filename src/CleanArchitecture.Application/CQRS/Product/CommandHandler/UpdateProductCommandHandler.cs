using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.CQRS.Product.Command;
using CleanArchitecture.Application.DatabaseServices.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.CQRS.Product.CommandHandler
{
    public class UpdateProductCommandHandler : BaseProductHandler,IRequestHandler<UpdateProductCommand, bool>
    {
        public UpdateProductCommandHandler(IProductService productDataService) : base(productDataService)
        {
        }
        public async Task<bool> Handle(UpdateProductCommand updateProductCommandRequest, CancellationToken cancellationToken)
        {
            var result = await base._productDataService.UpdateProduct(updateProductCommandRequest);
            return result;
        }
    }
}
