using AutoMapper;
using BankingCreditSystem.Application.Features.Category.Dtos.Response;
using BankingCreditSystem.Application.Features.Product.Constants;
using BankingCreditSystem.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingCreditSystem.Application.Features.Category.Queries.GetById
{
    public class GetByIdCategoryQuery : IRequest<CategoryResponse>
    {
        public int Id { get; set; }
        public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQuery, CategoryResponse>
        {
            private readonly IMapper _mapper;
            private readonly ICategoryRepository _categoryRepository;
            public GetByIdCategoryQueryHandler(IMapper mapper, ICategoryRepository categoryRepository)
            {
                _mapper = mapper;
                _categoryRepository = categoryRepository;
            }
            public async Task<CategoryResponse> Handle(GetByIdCategoryQuery request, CancellationToken cancellationToken)
            {
                var category = await _categoryRepository.GetAsync(c => c.Id == request.Id);

                if(category == null)
                    throw new BusinessException(ProductMessages.CategoryNotFound);

                var respone = _mapper.Map<CategoryResponse>(category);
                return respone;
            }
        }
    }
}
