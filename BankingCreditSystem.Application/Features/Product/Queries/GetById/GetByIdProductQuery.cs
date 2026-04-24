using AutoMapper;
using BankingCreditSystem.Application.Features.Product.Dtos.Response;
using BankingCreditSystem.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingCreditSystem.Application.Features.Product.Queries.GetById
{
    public class GetByIdProductQuery : IRequest<ProductResponse>
    {
        public Guid Id { get; set; }

        public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQuery, ProductResponse>
        {
            private readonly IMapper _mapper;
            private readonly IProductRepository _productRepository;
            public GetByIdProductQueryHandler(IMapper mapper, IProductRepository productRepository)
            {
                _mapper = mapper;   
                _productRepository = productRepository;
            }
            public async Task<ProductResponse> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
            {
                var product = await _productRepository.GetAsync(p => p.Id == request.Id);

                var response = _mapper.Map<ProductResponse>(product);
                return response;
            }
        }

    }
}
