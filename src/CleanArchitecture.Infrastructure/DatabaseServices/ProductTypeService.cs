using CleanArchitecture.Application.DatabaseServices.Interfaces;
using CleanArchitecture.Application.Models;
using System;
using System.Collections.Generic;
using Dapper;
using System.Threading.Tasks;
using System.Linq;
using SqlKata.Execution;
using SqlKata.Compilers;
using CleanArchitecture.Application.CQRS.ProductType.Command;
using CleanArchitecture.Application.Models.ProductType;

namespace CleanArchitecture.Infrastructure.DatabaseServices
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly IDatabaseConnectionFactory _database;

        public ProductTypeService(IDatabaseConnectionFactory database)
        {
            _database = database;
        }

        public async Task<bool> CreateProductType(CreateProductTypeCommand request)
        {
            using var conn = await _database.CreateConnectionAsync();
            var db = new QueryFactory(conn, new SqlServerCompiler());

            //if (!await IsProductTypeKeyUnique(db, request.Name, Guid.Empty))
            //    return false;

            //var affectedRecords = await db.Query("ProductType").InsertAsync(new
            //{
            //    ProductTypeID = Guid.NewGuid(),
            //    ProductTypeKey = request.ProductTypeKey,
            //    ProductTypeName = request.ProductTypeName,
            //    RecordStatus = request.RecordStatus,
            //    CreatedDate = DateTime.UtcNow,
            //    UpdatedUser = Guid.NewGuid()
            //});
            //return affectedRecords > 0;

            var parameters = new
            {
                ProductTypeKey = request.ProductTypeKey,
                ProductTypeName = request.ProductTypeName,
                RecordStatus = request.RecordStatus,
                CreatedDate = DateTime.UtcNow,
                UpdatedUser = Guid.NewGuid()
            };
            var affectedRecords = await conn.ExecuteAsync("INSERT INTO ProductType(ProductTypeKey, ProductTypeName, RecordStatus,CreatedDate, UpdatedUser) " +
                "VALUES(@ProductTypeKey, @ProductTypeName, @RecordStatus, @CreatedDate, @UpdatedUser)",
                parameters);
            return affectedRecords > 0;
        }

        public async Task<bool> DeleteProductType(Guid productTypeId)
        {
            using var conn = await _database.CreateConnectionAsync();
            //var db = new QueryFactory(conn, new SqlServerCompiler());
            //var affectedRecord = await db.Query("ProductType").Where("ProductTypeID", "=", productTypeId).DeleteAsync();

            //var parameters = new
            //{
            //    ProductTypeID = productTypeId
            //};
            //var affectedRecords = await conn.ExecuteAsync("DELETE FROM ProductType where ProductTypeID = @ProductTypeID",
            //    parameters);
            //return affectedRecords > 0;

            var parameters = new
            {
                ProductTypeID = productTypeId
            };
            var affectedRecords = await conn.ExecuteAsync("DELETE FROM ProductType where ProductTypeID = @ProductTypeID",
                parameters);
            return affectedRecords > 0;
        }

        public async Task<IEnumerable<ProductTypeResponseModel>> FetchProductType()
        {
            using var conn = await _database.CreateConnectionAsync();
            //var db = new QueryFactory(conn, new SqlServerCompiler());
            //var result = db.Query("ProductType");
            //return await result.GetAsync<ProductTypeResponseModel>();

            var result = conn.Query<ProductTypeResponseModel>("Select * from ProductType").ToList();
            return result;
        }
        public async Task<ProductTypeDetailsResponseModel> GetProductTypeDetails(Guid productTypeId)
        {
            using var conn = await _database.CreateConnectionAsync();
            //var db = new QueryFactory(conn, new SqlServerCompiler());
            //var result = db.Query("ProductType").Where("ProductTypeID", "=", productTypeId);
            //return await result.FirstOrDefaultAsync<ProductTypeDetailsResponseModel>();
            var parameters = new { ProductTypeID = productTypeId };
            var result = await conn.QueryFirstAsync<ProductTypeDetailsResponseModel>
                ("Select top 1 * from ProductType where ProductTypeID = @ProductTypeID", parameters);
            return result;
        }
        public async Task<bool> UpdateProductType(UpdateProductTypeCommand request)
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
                ProductTypeID = request.ProductTypeID,
                ProductTypeKey = request.ProductTypeKey,
                ProductTypeName = request.ProductTypeName,
                RecordStatus = request.RecordStatus,
                UpdatedDate = DateTime.UtcNow,
                UpdatedUser = Guid.NewGuid()
            };
            var affectedRecords = await conn.ExecuteAsync("UPDATE ProductType SET ProductTypeKey=@ProductTypeKey, ProductTypeName=@ProductTypeName," +
                " RecordStatus=@RecordStatus, UpdatedDate=@UpdatedDate, UpdatedUser=@UpdatedUser WHERE ProductTypeID = @ProductTypeID",
                parameters);
            return affectedRecords > 0;
        }
        private async Task<bool> IsProductTypeKeyUnique(QueryFactory db, string productTypeKey, Guid productTypeID)
        {
            var result = await db.Query("ProductType").Where("ProductTypeKey", "=", productTypeKey)
                .FirstOrDefaultAsync<ProductTypeDetailsResponseModel>();

            if (result == null)
                return true;

            return result.ProductTypeID == productTypeID;
        }
    }
}
