using System;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Application.Models.ProductType
{
    public class ProductTypeResponseModel
    {
        public Guid ProductTypeID { get; set; }
        public string ProductTypeKey { get; set; }
        public string ProductTypeName { get; set; }
        public RecordStatus RecordStatus { get; set; }
    }
}
