using AutoMapper;
using BankingCreditSystem.Application.Features.Product.Dtos.Response;
using BankingCreditSystem.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingCreditSystem.Application.Features.Product.Commands.Delete
{
    public class DeleteProductCommand : IRequest<DeletedProductResponse>
    {
        public Guid Id { get; set; }
        public class DeletedProductCommandHandler : IRequestHandler<DeleteProductCommand, DeletedProductResponse>
        {
            private readonly IProductRepository _productRepository;
            public DeletedProductCommandHandler(IProductRepository productRepository)
            {
                _productRepository = productRepository;
            }
            public async Task<DeletedProductResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
            {
                var product = await _productRepository.GetAsync(p  => p.Id == request.Id);
                if (product == null) {
                    return new DeletedProductResponse() { Id = request.Id, Message = "Ürün bulunamadı" };
                }
                var response = await _productRepository.DeleteAsync(product);

                if (response != null)
                {
                    return new DeletedProductResponse() { Id = request.Id, Message = "Silme işlemi başarılı" };
                }

                return new DeletedProductResponse() { Id = request.Id, Message = "Silme işlemi başarısız" };
            }
        }
    }
}
