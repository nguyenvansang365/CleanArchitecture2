using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.CQRS.Product.Command;
using CleanArchitecture.Application.DatabaseServices.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.CQRS.Product.CommandHandler
{
    public class CreateProductCommandHandler : BaseProductHandler, IRequestHandler<CreateProductCommand, bool>
    {
        public CreateProductCommandHandler(IProductService productDataService) : base(productDataService)
        {
        }

        public async Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var result = await base._productDataService.CreateProduct(request);
            return result;
        }
    }
}
