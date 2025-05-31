using AutoMapper;
using BankingCreditSystem.Application.Features.IndividualCustomers.Commands.Create;
using BankingCreditSystem.Domain.Entities;

namespace BankingCreditSystem.Application.Features.IndividualCustomers.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<IndividualCustomer, IndividualCustomerResponse>();
            CreateMap<IndividualCustomer, CreatedIndividualCustomerResponse>();
            CreateMap<IndividualCustomer, UpdatedIndividualCustomerResponse>();
            
            CreateMap<CreateIndividualCustomerRequest, IndividualCustomer>();
            CreateMap<UpdateIndividualCustomerRequest, IndividualCustomer>();

           

        }
    }
} 