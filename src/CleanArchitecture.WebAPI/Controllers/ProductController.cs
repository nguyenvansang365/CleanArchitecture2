using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchitecture.Application.CQRS.Product.Command;
using CleanArchitecture.Application.CQRS.Product.Query;
using CleanArchitecture.Application.DatabaseServices.Interfaces;
using CleanArchitecture.Application.Models.Product;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebAPI.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class ProductController : CustomBaseApiController
    {
        //private readonly IProductService _productService;
        //public ProductController(IProductService productService )
        //{
        //    _productService = productService;
        //}
        public ProductController(IMediator mediator) : base(mediator)
        {

        }

        // We can update search criteria later
        [HttpGet]
        public async Task<IEnumerable<ProductResponseModel>> Get()
        {
            var query = new FetchProductQuery();
            return await Mediator.Send(query);
        }

        //// GET api/Product/ProductID
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDetailsResponseModel>> Get(Guid id)
        {
            var query = new GetProductDetailsQuery() { ProductId = id };
            return await Mediator.Send(query);
        }

        // POST
        [HttpPost]
        public async Task<ActionResult<bool>> Post(CreateProductCommand command)
        {
            //var result = await _productService.CreateProduct(model);
            //return result;
            return await Mediator.Send(command);
        }

        // PUT 
        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> Put(Guid id, [FromBody] UpdateProductCommand request)
        {
            request.ProductID = id;
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