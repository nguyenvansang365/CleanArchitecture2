using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchitecture.Application.CQRS.Product.Command;
using CleanArchitecture.Application.Models.Product;

namespace CleanArchitecture.Application.DatabaseServices.Interfaces
{
    public interface IProductService
    {
        Task<bool> CreateProduct(CreateProductCommand request);
        Task<bool> UpdateProduct(UpdateProductCommand request);
        Task<bool> DeleteProduct(Guid productTypeId);
        Task<ProductDetailsResponseModel> GetProductDetails(Guid productId);
        Task<IEnumerable<ProductResponseModel>> FetchProduct();
    }
}
