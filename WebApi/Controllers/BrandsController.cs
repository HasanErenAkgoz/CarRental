using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Queryies.GetAll;
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

        [HttpGet]
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

    }
}
