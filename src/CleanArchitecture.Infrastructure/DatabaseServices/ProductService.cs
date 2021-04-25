using CleanArchitecture.Application.DatabaseServices;
using CleanArchitecture.Application.Models;
using System;
using System.Collections.Generic;
using Dapper;
using System.Threading.Tasks;
using System.Linq;
using SqlKata.Execution;
using SqlKata.Compilers;

namespace CleanArchitecture.Infrastructure.DatabaseServices
{
    public class ProductService : IProductService
    {
        private readonly IDatabaseConnectionFactory _database;

        public ProductService(IDatabaseConnectionFactory database)
        {
            _database = database;
        }

        public async Task<bool> CreateProduct(Product request)
        {
            using var conn = await _database.CreateConnectionAsync();
            var db = new QueryFactory(conn, new SqlServerCompiler());

            //if (!await IsProductKeyUnique(db, request.Name, Guid.Empty))
            //    return false;

            var affectedRecords = await db.Query("Product").InsertAsync(new
            {
                ProductID = Guid.NewGuid(),
                ProductKey = request.ProductKey,
                ProductName = request.ProductName,
                ProductImageUri = request.ProductImageUri,
                ProductTypeID = request.ProductTypeID,
                RecordStatus = request.RecordStatus,
                CreatedDate = DateTime.UtcNow,
                UpdatedUser = Guid.NewGuid()
            });
            //var parameters = new
            //{
            //    Id = Guid.NewGuid(),
            //    Name = request.Name,
            //    RecordStatus = request.Status,
            //    CreatedDate = DateTime.UtcNow,
            //    UpdatedUser = Guid.NewGuid()
            //};
            //var affectedRecords = await conn.ExecuteAsync("INSERT INTO Product(ProductID, ProductKey, ProductName, RecordStatus,CreatedDate, UpdatedUser) " +
            //    "VALUES(@ProductID, @ProductKey, @ProductName, @RecordStatus, @CreatedDate, @UpdatedUser)",
            //    parameters);
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

        public async Task<IEnumerable<Product>> FetchProduct()
        {
            using var conn = await _database.CreateConnectionAsync();
            //var db = new QueryFactory(conn, new SqlServerCompiler());
            //var result = db.Query("Product");
            //return await result.GetAsync<ProductResponseModel>();

            var result = conn.Query<Product>("Select * from Product").ToList();
            return result;
        }

        private async Task<bool> IsProductKeyUnique(QueryFactory db, string productKey, Guid productID)
        {
            var result = await db.Query("Product").Where("ProductKey", "=", productKey)
                .FirstOrDefaultAsync<Product>();

            if (result == null)
                return true;

            return result.ProductID == productID;
        }
    }
}
