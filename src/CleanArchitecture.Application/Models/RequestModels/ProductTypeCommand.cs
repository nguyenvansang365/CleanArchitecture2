using CleanArchitecture.Application.Models.ResponseModels;
using CleanArchitecture.Domain.Entites;
using CleanArchitecture.Domain.Enums;
using MediatR;
using System;

namespace CleanArchitecture.Application.Models.RequestModels
{
    public class ProductTypeCommand: IRequest<ProductTypeCommandResponseModel>
    {
        public Guid ProductTypeID { get; set; }
        public string ProductTypeKey { get; set; }
        public string ProductTypeName { get; set; }
        public RecordStatus RecordStatus { get; set; }
    }
}
