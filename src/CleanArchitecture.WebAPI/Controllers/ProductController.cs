﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchitecture.Application.DatabaseServices;
using CleanArchitecture.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService )
        {
            _productService = productService;
        }

        // We can update search criteria later
        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            var result = await _productService.FetchProduct();
            return result;
        }

        //// GET api/Product/ProductID
        //[HttpGet("{id}")]
        //public async Task<ActionResult<ProductDetailsResponseModel>> Get(Guid id)
        //{
        //    var query = new GetProductDetailsQuery() { ProductId = id };
        //    return await Mediator.Send(query);
        //}

        // POST
        [HttpPost]
        public async Task<ActionResult<bool>> Post(Product model)
        {
            var result = await _productService.CreateProduct(model);
            return result;
        }

        //// PUT 
        //[HttpPut("{id}")]
        //public async Task<ActionResult<bool>> Put(Guid id, [FromBody]UpdateProductCommand request)
        //{
        //    request.ProductID = id;
        //    return await Mediator.Send(request);
        //}

        // DELETE 
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(Guid id)
        {
            var result = await _productService.DeleteProduct(id);
            return result;
        }
    }
}