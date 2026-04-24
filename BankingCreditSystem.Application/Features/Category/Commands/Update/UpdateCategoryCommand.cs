using AutoMapper;
using BankingCreditSystem.Application.Features.Category.Dtos.Requests;
using BankingCreditSystem.Application.Features.Category.Dtos.Response;
using BankingCreditSystem.Application.Services.Repositories;
using BankingCreditSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingCreditSystem.Application.Features.Category.Commands.Update
{
    public class UpdateCategoryCommand : IRequest<UpdatedCategoryResponse>
    {
        public UpdateCategoryRequest Request { get; set; } = default!;

        public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, UpdatedCategoryResponse>
        {
            private readonly IMapper _mapper;
            private readonly ICategoryRepository _categoryRepository;
            public UpdateCategoryCommandHandler(IMapper mapper, ICategoryRepository categoryRepository)
            {
                _mapper = mapper;
                _categoryRepository = categoryRepository;
            }
            public async Task<UpdatedCategoryResponse> Handle(UpdateCategoryCommand command, CancellationToken cancellationToken)
            {
                var category = await _categoryRepository.GetAsync(c => c.Id == command.Request.Id);

                if(category == null)
                    return new UpdatedCategoryResponse() { Message = "Kategori bulunamadı" };

                _mapper.Map(command.Request, category);

                var updatedResponse = await _categoryRepository.UpdateAsync(category);

                if (updatedResponse == null)
                    return new UpdatedCategoryResponse() { Message = "Kategori güncellenemedi" };

                var response = _mapper.Map<UpdatedCategoryResponse>(updatedResponse);
                response.Message = "Güncelleme başarılı";
                return response;
            }
        }
    }
}
