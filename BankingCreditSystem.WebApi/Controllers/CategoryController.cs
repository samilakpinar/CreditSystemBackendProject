using BankingCreditSystem.Application.Features.Category.Commands.Create;
using BankingCreditSystem.Application.Features.Category.Commands.Delete;
using BankingCreditSystem.Application.Features.Category.Commands.Update;
using BankingCreditSystem.Application.Features.Category.Queries.GetById;
using BankingCreditSystem.Application.Features.Category.Queries.GetList;
using BankingCreditSystem.Application.Features.CorporateCustomers.Commands.Delete;
using BankingCreditSystem.Application.Features.CorporateCustomers.Commands.Update;
using BankingCreditSystem.Application.Features.CorporateCustomers.Queries.GetById;
using BankingCreditSystem.Application.Features.Product.Commands.Create;
using BankingCreditSystem.Application.Features.Product.Queries.GetList;
using Microsoft.AspNetCore.Mvc;

namespace BankingCreditSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryCommand createCategoryCommand)
        {
            var result = await Mediator.Send(createCategoryCommand);
            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] GetListCategoryQuery getListCategoryQuery)
        {
            var result = await Mediator.Send(getListCategoryQuery);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var query = new GetByIdCategoryQuery { Id = id };
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var command = new DeleteCategoryCommand() { Id = id };
            var result = await Mediator.Send(command);
            return Ok(result);
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryCommand updateCategoryCommand)
        {
            var result = await Mediator.Send(updateCategoryCommand);
            return Ok(result);
        }

    }
}
