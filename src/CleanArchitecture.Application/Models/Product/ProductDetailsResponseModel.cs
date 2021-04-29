using System;
using CleanArchitecture.Domain.Entites;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Application.Models.Product
{
    public class ProductDetailsResponseModel: AuditableEntity
    {
        public Guid ProductID { get; set; }
        public string ProductKey { get; set; }
        public string ProductName { get; set; }
        public string ProductImageUri { get; set; }
        public string ProductTypeName { get; set; }
        public RecordStatus RecordStatus { get; set; }
    }
}
