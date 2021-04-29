﻿using CleanArchitecture.Application.Models.ResponseModels;
using CleanArchitecture.Domain.Entites;
using CleanArchitecture.Domain.Enums;
using MediatR;
using System;

namespace CleanArchitecture.Application.Models.RequestModels
{
    public class ProductCommand: IRequest<ProductCommandResponseModel>
    {
        public Guid ProductID { get; set; }
        public string ProductKey { get; set; }
        public string ProductName { get; set; }
        public string ProductImageUri { get; set; }
        public Guid ProductTypeID { get; set; }
        public RecordStatus RecordStatus { get; set; }
    }
}