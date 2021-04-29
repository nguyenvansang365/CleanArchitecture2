using CleanArchitecture.Domain.Entites;
using CleanArchitecture.Domain.Enums;
using System;

namespace CleanArchitecture.Application.Models.ResponseModels
{
    public class ProductTypeCommandResponseModel
    {
        public bool IsSuccess { get; set; }
        public Guid ProductTypeID { get; set; }
    }
}
