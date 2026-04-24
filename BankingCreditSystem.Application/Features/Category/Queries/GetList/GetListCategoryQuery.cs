using AutoMapper;
using BankingCreditSystem.Application.Features.Category.Dtos.Response;
using BankingCreditSystem.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingCreditSystem.Application.Features.Category.Queries.GetList
{
    public class GetListCategoryQuery : IRequest<Paginate<CategoryResponse>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        class GetListCategoryQueryHandler : IRequestHandler<GetListCategoryQuery, Paginate<CategoryResponse>>
        {
            private readonly IMapper _mapper;
            private readonly ICategoryRepository _categoryRepository;
            public GetListCategoryQueryHandler(IMapper mapper, ICategoryRepository categoryRepository)
            {
                _mapper = mapper;
                _categoryRepository = categoryRepository;
            }

            public async Task<Paginate<CategoryResponse>> Handle(GetListCategoryQuery request, CancellationToken cancellationToken)
            {
                var categories = await _categoryRepository.GetListAsync(index:request.PageIndex, size:request.PageSize, cancellationToken:cancellationToken);

                var response = _mapper.Map<Paginate<CategoryResponse>>(categories);

                return response;
            }
        }
    }
}
