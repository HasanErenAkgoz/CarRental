using Application.Features.Models.Queryies.GetAll;
using Application.Features.Models.Queryies.GetListByDynamic;
using AutoMapper;
using Core.Application.Request;
using Core.Application.Responses;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ModelController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] PageRequest request)
    {
        GetAllModelQuery getAllModelQuery = new GetAllModelQuery{PageRequest = request};
        GetAllResponse<GetAllModelListItemDto> response = await Mediator.Send(getAllModelQuery);
        return Ok(response);
    }

    [HttpPost("GetAll/ByDynamic")]
    public async Task<IActionResult> GetAllByDynamicModel([FromQuery] PageRequest request,
        [FromBody] DynamicQuery? dynamicQuery)
    {
        GetAllByDynamicModelQuery getAllByDynamicModelQuery = new GetAllByDynamicModelQuery { PageRequest = request, DynamicQuery = dynamicQuery };
        GetAllResponse<GetAllByDynamicModelListItemDto> response = await Mediator.Send(getAllByDynamicModelQuery);
        return Ok(response);
    }
    
}