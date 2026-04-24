using BankingCreditSystem.Application.Features.Category.Commands.Update;
using BankingCreditSystem.Application.Features.CorporateCustomers.Commands.Delete;
using BankingCreditSystem.Application.Features.CorporateCustomers.Queries.GetById;
using BankingCreditSystem.Application.Features.CorporateCustomers.Queries.GetList;
using BankingCreditSystem.Application.Features.Product.Commands.Create;
using BankingCreditSystem.Application.Features.Product.Commands.Delete;
using BankingCreditSystem.Application.Features.Product.Commands.Update;
using BankingCreditSystem.Application.Features.Product.Queries.GetById;
using BankingCreditSystem.Application.Features.Product.Queries.GetList;
using Microsoft.AspNetCore.Mvc;

namespace BankingCreditSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductCommand createProductCommand)
        {
            var result = await Mediator.Send(createProductCommand);
            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] GetListProductQuery getListProductQuery)
        {
            var result = await Mediator.Send(getListProductQuery);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var query = new GetByIdProductQuery { Id = id };
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var command = new DeleteProductCommand { Id = id };
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProductCommand updateProductCommand)
        {
            var result = await Mediator.Send(updateProductCommand);
            return Ok(result);
        }
    }
}
