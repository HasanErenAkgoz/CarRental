using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Commands.Delete;
using Application.Features.Brands.Commands.Update;
using Application.Features.Brands.Queryies.GetAll;
using Application.Features.Brands.Queryies.GetById;
using Core.Application.Request;
using Core.Application.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : BaseController
    {

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            GetAllBrandQuery getAllBrandQuery = new GetAllBrandQuery { PageRequest = pageRequest };
            GetAllResponse<GetAllBrandListItemDto> response = await Mediator.Send(getAllBrandQuery);
            if (response.Items != null)
            {
                return Ok(response);
            }
            else { return BadRequest(); }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            GetByIdBrandQuery getbyIdBrandQuery = new GetByIdBrandQuery { Id = id };
            GetByIdBrandResponse response = await Mediator.Send(getbyIdBrandQuery);
            if (response != null)
            {
                return Ok(response);
            }
            else { return BadRequest(); }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBrandCommand createBrandCommand)
        {
            CreatedBrandResponse response = await Mediator.Send(createBrandCommand);
            if (response != null)
            {
                return Ok(response);
            }
            else { return BadRequest(); }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatedBrandCommand updatedBrandCommand)
        {
            UpdatedBrandResponse response = await Mediator.Send(updatedBrandCommand);
            return Ok(response);
         
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            DeleteBrandCommand deleteBrandCommand = new DeleteBrandCommand { Id = id };
            DeleteBrandResponse response = await Mediator.Send(deleteBrandCommand);
            return  Ok(response);
        }
    }
}
