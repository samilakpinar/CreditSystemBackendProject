using AutoMapper;
using BankingCreditSystem.Application.Features.Category.Dtos.Response;
using BankingCreditSystem.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingCreditSystem.Application.Features.Category.Commands.Delete
{
    public class DeleteCategoryCommand : IRequest<DeletedCategoryResponse>
    {
        public int Id { get; set; }
        public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, DeletedCategoryResponse>
        {
            private readonly ICategoryRepository _categoryRepository;
            public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
            {
                _categoryRepository = categoryRepository;
            }
            public async Task<DeletedCategoryResponse> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
            {
                var category = await _categoryRepository.GetAsync(c => c.Id ==  request.Id);

                if(category == null)
                    return new DeletedCategoryResponse() { Id = request.Id, Message = "Kategori bulunamadı" };

                var deletedCategory = await _categoryRepository.DeleteAsync(category);

                if(deletedCategory != null) 
                    return new DeletedCategoryResponse() { Id= deletedCategory.Id, Message = "Silme işlemi başarılı"};

                return new DeletedCategoryResponse() { Id = request.Id, Message = "Silme işlemi başarısız" };

            }
        }
    }
}
