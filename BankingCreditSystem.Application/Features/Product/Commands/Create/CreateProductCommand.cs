using AutoMapper;
using BankingCreditSystem.Application.Features.Product.Constants;
using BankingCreditSystem.Application.Features.Product.Dtos.Requests;
using BankingCreditSystem.Application.Features.Product.Dtos.Response;
using BankingCreditSystem.Application.Services.Repositories;
using BankingCreditSystem.Domain.Entities;
using MediatR;

namespace BankingCreditSystem.Application.Features.Product.Commands.Create
{
    public class CreateProductCommand : IRequest<CreatedProductResponse>
    {
        public CreateProductRequest Request { get; set; } = default!;

        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreatedProductResponse>
        {
            private readonly IProductRepository _productRepository;
            private readonly ICategoryRepository _categoryRepository;
            private readonly IMapper _mapper;
            public CreateProductCommandHandler(
                IMapper mapper,
                IProductRepository productRepository,
                ICategoryRepository categoryRepository)
            {
                _mapper = mapper;
                _productRepository = productRepository;
                _categoryRepository = categoryRepository;
            }
            public async Task<CreatedProductResponse> Handle(CreateProductCommand command, CancellationToken cancellationToken)
            {
                if (command.Request.CategoryId <= 0 ||
                    !await _categoryRepository.AnyAsync(
                        c => c.Id == command.Request.CategoryId,
                        cancellationToken: cancellationToken))
                {
                    throw new BusinessException(ProductMessages.CategoryNotFound);
                }

                //var product = _mapper.Map<Domain.Entities.Product>(command.Request);

                var product = new Domain.Entities.Product()
                {
                    Id = Guid.NewGuid(),
                    Name = command.Request.Name,
                    Type = command.Request.Type,
                    CategoryId = command.Request.CategoryId,
                    SupplierId = command.Request.SupplierId,
                    StockCode = command.Request.StockCode,
                    Price = command.Request.Price,
                    CostPrice = command.Request.CostPrice,
                    Description = command.Request.Description,
                    Slug = command.Request.Slug,
                    VideoPath = "",
                    VideoStatus = "",
                    VideoThumbPath = "",
                    BrandId = command.Request.BrandId,
                    TotalQuantity = command.Request.TotalQuantity
                };

                var createdProduct = await _productRepository.AddAsync(product);

                var response = new Application.Features.Product.Dtos.Response.CreatedProductResponse();
                response.Message = "başarılı";

                return response;
            }
        }

    }
}
