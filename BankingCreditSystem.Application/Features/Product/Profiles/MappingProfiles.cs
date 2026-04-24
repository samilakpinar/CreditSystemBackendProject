using AutoMapper;
using BankingCreditSystem.Application.Features.Product.Dtos.Requests;
using BankingCreditSystem.Application.Features.Product.Dtos.Response;
using BankingCreditSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingCreditSystem.Application.Features.Product.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Paginate<Domain.Entities.Product>, Paginate<ProductResponse>>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));

            CreateMap<Domain.Entities.Product, ProductResponse>();

            CreateMap<Domain.Entities.Product, UpdatedProductResponse>();

            CreateMap<UpdateProductRequest, Domain.Entities.Product>();

        }
    }
}
