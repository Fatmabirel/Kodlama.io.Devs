using Application.Features.SocialMediaAddresses.Commands.CreateSocialMediaAddress;
using Application.Features.SocialMediaAddresses.Commands.DeleteSocialMediaAddress;
using Application.Features.SocialMediaAddresses.Commands.UpdateSocialMediaAddress;
using Application.Features.SocialMediaAddresses.Dtos;
using Application.Features.SocialMediaAddresses.Models;
using Application.Features.SocialMediaAddresses.Queries.GetByIdSocialMediaAddress;
using Application.Features.SocialMediaAddresses.Queries.GetListSocialMediaAddress;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaAddressesController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListSocialMediaAddressQuery getListSocialMediaAddressQuery = new GetListSocialMediaAddressQuery { PageRequest = pageRequest };
            SocialMediaAddressListModel socialMediaAddressListModel = await Mediator.Send(getListSocialMediaAddressQuery);
            return Ok(socialMediaAddressListModel);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateSocialMediaAddressCommand createSocialMediaAddressCommand)
        {
            CreatedSocialMediaAddressDto createdSocialMediaAddressDto = await Mediator.Send(createSocialMediaAddressCommand);
            return Ok(createdSocialMediaAddressDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateSocialMediaAddressCommand updateSocialMediaAddressCommand)
        {
            UpdatedSocialMediaAddressDto result = await Mediator.Send(updateSocialMediaAddressCommand);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteSocialMediaAddressCommand deleteSocialMediaAddressCommand)
        {
            DeletedSocialMediaAddressDto result = await Mediator.Send(deleteSocialMediaAddressCommand);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdSocialMediaAddressQuery getByIdSocialMediaAddressQuery)
        {
            SocialMediaAddressGetByIdDto result = await Mediator.Send(getByIdSocialMediaAddressQuery);
            return Ok(result);
        }
    }
}
