using AutoMapper;
using BankingCreditSystem.Application.Features.Category.Dtos.Requests;
using BankingCreditSystem.Application.Features.Category.Dtos.Response;
using BankingCreditSystem.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingCreditSystem.Application.Features.Category.Commands.Create
{
    public class CreateCategoryCommand : IRequest<CreatedCategoryResponse>
    {
        public CreateCategoryRequest Request { get; set; }
        public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreatedCategoryResponse>
        {
            private readonly IMapper _mapper;
            private readonly ICategoryRepository _categoryRepository;
            public CreateCategoryCommandHandler(IMapper mapper, ICategoryRepository categoryRepository)
            {
                _mapper = mapper;
                _categoryRepository = categoryRepository;
            }

            public async Task<CreatedCategoryResponse> Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
            {
                var category = _mapper.Map<Domain.Entities.Category>(command.Request);

                var response = await _categoryRepository.AddAsync(category);

                var categoryDto = _mapper.Map<CreatedCategoryResponse>(response);

                return categoryDto;
            }
        }
    }
}
