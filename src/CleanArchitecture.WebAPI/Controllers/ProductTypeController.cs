using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchitecture.Application.CQRS.Product.Command;
using CleanArchitecture.Application.CQRS.ProductType.Command;
using CleanArchitecture.Application.CQRS.ProductType.Query;
using CleanArchitecture.Application.Models.ProductType;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebAPI.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class ProductTypeController : CustomBaseApiController
    {
        public ProductTypeController(IMediator mediator) : base(mediator)
        {

        }

        // We can update search criteria later
        [HttpGet]
        public async Task<IEnumerable<ProductTypeResponseModel>> Get()
        {
            //var result = await _productTypeService.FetchProductType();
            //return result;
            var query = new FetchProductTypeQuery();
            return await Mediator.Send(query);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductTypeDetailsResponseModel>> Get(Guid id)
        {
            var query = new GetProductTypeDetailsQuery() { ProductTypeId = id };
            return await Mediator.Send(query);
        }

        // POST
        [HttpPost]
        public async Task<ActionResult<bool>> Post(CreateProductTypeCommand command)
        {
            return await Mediator.Send(command);
        }

        // PUT 
        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> Put(Guid id, [FromBody] UpdateProductCommand request)
        {
            request.ProductTypeID = id;
            return await Mediator.Send(request);
        }

        // DELETE 
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(Guid id)
        {
            var query = new DeleteProductCommand() { ProductID = id };
            return await Mediator.Send(query);
        }
    }
}