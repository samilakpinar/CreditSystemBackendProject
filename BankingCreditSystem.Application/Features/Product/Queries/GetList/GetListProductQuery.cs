using AutoMapper;
using BankingCreditSystem.Application.Features.CorporateCustomers.Queries.GetList;
using BankingCreditSystem.Application.Features.Product.Dtos.Response;
using BankingCreditSystem.Application.Services.Repositories;
using BankingCreditSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingCreditSystem.Application.Features.Product.Queries.GetList
{
    public class GetListProductQuery : IRequest<Paginate<ProductResponse>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public class GetListProductQuertHandler : IRequestHandler<GetListProductQuery, Paginate<ProductResponse>>
        {
            private readonly IMapper _mapper;
            private readonly IProductRepository _productRepository;
            public GetListProductQuertHandler(IMapper mapper, IProductRepository productRepository)
            {
                _mapper = mapper;
                _productRepository = productRepository;
            }

            public async Task<Paginate<ProductResponse>> Handle(GetListProductQuery request, CancellationToken cancellationToken)
            {
                var products = await _productRepository.GetListAsync(
                     index: request.PageIndex,
                     size: request.PageSize,
                     cancellationToken: cancellationToken
                     );

                var response = _mapper.Map<Paginate<ProductResponse>>(products);
                return response;
            }
        }
    }
}
