using AutoMapper;
using BankingCreditSystem.Application.Features.Category.Dtos.Requests;
using BankingCreditSystem.Application.Features.Category.Dtos.Response;
using BankingCreditSystem.Application.Features.Product.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingCreditSystem.Application.Features.Category.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Domain.Entities.Category, CategoryResponse>();

            CreateMap<Paginate<Domain.Entities.Category>, Paginate<CategoryResponse>>()
             .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));

            CreateMap<CreateCategoryRequest, Domain.Entities.Category>();
            CreateMap<Domain.Entities.Category, CreatedCategoryResponse>();
            CreateMap<Domain.Entities.Category,UpdatedCategoryResponse>();
            CreateMap<UpdateCategoryRequest, Domain.Entities.Category>();

        }
    }
}
