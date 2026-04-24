using AutoMapper;
using BankingCreditSystem.Application.Features.Category.Dtos.Response;
using BankingCreditSystem.Application.Features.Product.Dtos.Requests;
using BankingCreditSystem.Application.Features.Product.Dtos.Response;
using BankingCreditSystem.Application.Services.Repositories;
using BankingCreditSystem.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingCreditSystem.Application.Features.Product.Commands.Update
{
    public class UpdateProductCommand : IRequest<UpdatedProductResponse>
    {
        public UpdateProductRequest Request { get; set; }

        public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, UpdatedProductResponse>
        {
            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;
            public UpdateProductCommandHandler(
                IMapper mapper,
                IProductRepository productRepository)
            {
                _mapper = mapper;
                _productRepository = productRepository;
            }
            public async Task<UpdatedProductResponse> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
            {
                var product = await _productRepository.GetAsync(p => p.Id == command.Request.Id);

                if (product == null)
                    return new UpdatedProductResponse() { Message = "güncellenecek ürün bulunamadı." };

                _mapper.Map(command.Request, product);

                var updatedProduct = await _productRepository.UpdateAsync(product);

                if (updatedProduct == null)
                    return new UpdatedProductResponse() { Message = "Ürün güncellenemedi" };

                var response = _mapper.Map<UpdatedProductResponse>(updatedProduct);
                response.Message = "Güncelleştirme Başarılı";
                return response;

            }
        }
    }
}
