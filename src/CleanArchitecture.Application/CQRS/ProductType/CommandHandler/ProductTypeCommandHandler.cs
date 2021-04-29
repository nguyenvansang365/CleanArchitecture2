//using CleanArchitecture.Application.Events;
//using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Models.RequestModels;
using CleanArchitecture.Application.Models.ResponseModels;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.CQRS.ProductType.CommandHandler
{
    public class ProductTypeCommandHandler : IRequestHandler<ProductTypeCommand, ProductTypeCommandResponseModel>
    {
        private readonly IMediator _mediator;
        public ProductTypeCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<ProductTypeCommandResponseModel> Handle(ProductTypeCommand request, CancellationToken cancellationToken)
        {
            var result = new ProductTypeCommandResponseModel();
            result.IsSuccess = true;
            //// Your logic here
            //var notification = new PushNotification {
            //    DateTime = DateTime.Now,
            //    Message = "This is a test notification from Order Commandhandler!"
            //};
            //_ = _mediator.Publish(notification);
            //Thread.Sleep(5000);
            return result;
        }
    }
}
