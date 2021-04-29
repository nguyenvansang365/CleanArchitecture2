using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchitecture.Application.CQRS.ProductType.Command;
using CleanArchitecture.Application.Models.ProductType;

namespace CleanArchitecture.Application.DatabaseServices.Interfaces
{
    public interface IProductTypeService
    {
        Task<bool> CreateProductType(CreateProductTypeCommand request);
        Task<bool> UpdateProductType(UpdateProductTypeCommand request);
        Task<bool> DeleteProductType(Guid productTypeId);
        Task<ProductTypeDetailsResponseModel> GetProductTypeDetails(Guid productTypeId);
        Task<IEnumerable<ProductTypeResponseModel>> FetchProductType();
    }
}
