using Microsoft.AspNetCore.Mvc;
using MediatR;
using BankingCreditSystem.Application.Features.IndividualCustomers.Commands.Create;
using BankingCreditSystem.Application.Features.IndividualCustomers.Queries.GetById;
using BankingCreditSystem.Application.Features.IndividualCustomers.Queries.GetList;

namespace BankingCreditSystem.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IndividualCustomersController : BaseController
{
   

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateIndividualCustomerCommand createIndividualCustomerCommand)
    {
        var result = await Mediator.Send(createIndividualCustomerCommand);
        return Created("", result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var query = new GetByIdIndividualCustomerQuery { Id = id };
        var result = await Mediator.Send(query);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] GetListIndividualCustomerQuery getListIndividualCustomerQuery)
    {
        var result = await Mediator.Send(getListIndividualCustomerQuery);
        return Ok(result);
    }
} 