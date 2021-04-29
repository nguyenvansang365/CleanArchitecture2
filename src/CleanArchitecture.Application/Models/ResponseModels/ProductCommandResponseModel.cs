using CleanArchitecture.Domain.Entites;
using CleanArchitecture.Domain.Enums;
using System;

namespace CleanArchitecture.Application.Models.ResponseModels
{
    public class ProductCommandResponseModel
    {
        public bool IsSuccess { get; set; }
        public Guid ProductID { get; set; }
    }
}
