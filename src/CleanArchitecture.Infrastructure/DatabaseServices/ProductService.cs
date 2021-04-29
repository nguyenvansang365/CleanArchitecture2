using CleanArchitecture.Application.DatabaseServices.Interfaces;
using CleanArchitecture.Application.Models;
using System;
using System.Collections.Generic;
using Dapper;
using System.Threading.Tasks;
using System.Linq;
using SqlKata.Execution;
using SqlKata.Compilers;
using CleanArchitecture.Application.CQRS.Product.Command;
using CleanArchitecture.Application.Models.Product;

namespace CleanArchitecture.Infrastructure.DatabaseServices
{
    public class ProductService : IProductService
    {
        private readonly IDatabaseConnectionFactory _database;

        public ProductService(IDatabaseConnectionFactory database)
        {
            _database = database;
        }

        public async Task<bool> CreateProduct(CreateProductCommand request)
        {
            using var conn = await _database.CreateConnectionAsync();
            var db = new QueryFactory(conn, new SqlServerCompiler());

            if (!await IsProductKeyUnique(db, request.ProductKey, Guid.Empty))
                return false;

            var affectedRecords = await db.Query("Product").InsertAsync(new
            {
                ProductId = Guid.NewGuid(),
                ProductKey = request.ProductKey,
                ProductName = request.ProductName,
                ProductImageUri = request.ProductImageUri,
                ProductTypeID = request.ProductTypeID,
                RecordStatus = request.RecordStatus,
                CreatedDate = DateTime.UtcNow,
                UpdatedUser = Guid.NewGuid()
            });

            return affectedRecords > 0;
        }

        public async Task<bool> DeleteProduct(Guid productId)
        {
            using var conn = await _database.CreateConnectionAsync();
            //var db = new QueryFactory(conn, new SqlServerCompiler());
            //var affectedRecord = await db.Query("Product").Where("ProductID", "=", ProductId).DeleteAsync();

            var parameters = new
            {
                ProductID = productId
            };
            var affectedRecords = await conn.ExecuteAsync("DELETE FROM Product where ProductID = @ProductID",
                parameters);
            return affectedRecords > 0;
        }

        public async Task<IEnumerable<ProductResponseModel>> FetchProduct()
        {
            using var conn = await _database.CreateConnectionAsync();
            //var db = new QueryFactory(conn, new SqlServerCompiler());
            //var result = db.Query("Product");
            //return await result.GetAsync<ProductResponseModel>();

            //var result = conn.Query<Product>("Select * from Product").ToList();

            //return result;
            var db = new QueryFactory(conn, new SqlServerCompiler());

            var result = db.Query("Product")
                .Select(
                "ProductID",
                "ProductKey",
                "ProductName",
                "ProductImageUri",
                "ProductTypeName",
                "Product.RecordStatus")
                .Join("ProductType", "ProductType.ProductTypeID", "Product.ProductTypeID")
                .OrderByDesc("Product.UpdatedDate")
                .OrderByDesc("Product.CreatedDate")
                .ForPage(3, 5);

            return await result.GetAsync<ProductResponseModel>();
        }
        public async Task<ProductDetailsResponseModel> GetProductDetails(Guid productId)
        {
            using var conn = await _database.CreateConnectionAsync();
         
            var parameters = new { ProductID = productId };
            var result = await conn.QueryFirstAsync<ProductDetailsResponseModel>
                ("Select top 1 * from Product where ProductID = @ProductID", parameters);
            return result;
        }
        public async Task<bool> UpdateProduct(UpdateProductCommand request)
        {
            using var conn = await _database.CreateConnectionAsync();
            //var db = new QueryFactory(conn, new SqlServerCompiler());

            //if (!await IsProductTypeKeyUnique(db, request.ProductTypeKey, request.ProductTypeId))
            //    return false;

            //var affectedRecord = await db.Query("ProductType").Where("ProductTypeID", "=", request.ProductTypeId).UpdateAsync(new
            //{
            //    ProductTypeKey = request.ProductTypeKey,
            //    ProductTypeName = request.ProductTypeName,
            //    RecordStatus = request.RecordStatus,
            //    UpdatedDate = DateTime.UtcNow,
            //    UpdatedUser = Guid.NewGuid()
            //}); 

            var parameters = new
            {
                ProductId = request.ProductID,
                ProductKey = request.ProductKey,
                ProductName = request.ProductName,
                ProductImageUri = request.ProductImageUri,
                ProductTypeID = request.ProductTypeID,
                RecordStatus = request.RecordStatus,
                CreatedDate = DateTime.UtcNow,
                UpdatedUser = Guid.NewGuid()
            };
            var affectedRecords = await conn.ExecuteAsync("UPDATE Product SET ProductKey=@ProductKey, ProductName=@ProductName, ProductImageUri=@ProductImageUri," +
                ",ProductTypeID = @ProductTypeID, RecordStatus=@RecordStatus, UpdatedDate=@UpdatedDate, UpdatedUser=@UpdatedUser WHERE ProductID = @ProductID",
                parameters);

            return affectedRecords > 0;
        }
        private async Task<bool> IsProductKeyUnique(QueryFactory db, string productKey, Guid productID)
        {
            //var result = await db.Query("Product").Where("ProductKey", "=", productKey)
            //    .FirstOrDefaultAsync<Product>();

            //if (result == null)
            //    return true;

            //return result.ProductID == productID;
            var result = await db.Query("Product").Where("ProductKey", "=", productKey)
                .FirstOrDefaultAsync<ProductResponseModel>();

            if (result == null)
                return true;

            return result.ProductID == productID;
        }
    }
}
