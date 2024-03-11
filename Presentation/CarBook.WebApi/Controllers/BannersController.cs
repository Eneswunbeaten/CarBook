using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Features.CQRS.Handlers.BannerHandlers;
using CarBook.Application.Features.CQRS.Queries.BannerQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController : ControllerBase
    {
        private readonly CreateBannerCommandHandler _createBannerHandler;
        private readonly GetBannerByIdQueryHandler _getBannerByIdQueryHandler;
        private readonly GetBannerQueryHandler _getBannerQueryHandler;
        private readonly RemoveBannerCommandHandler _removeBannerHandler;
        private readonly UpdateBannerCommandHandler _updateBannerHandler;

        public BannersController(CreateBannerCommandHandler createBannerHandler,
            GetBannerByIdQueryHandler getBannerByIdQueryHandler,
            GetBannerQueryHandler getBannerQueryHandler,
            RemoveBannerCommandHandler removeBannerHandler, 
            UpdateBannerCommandHandler updateBannerHandler)
        {
            _createBannerHandler = createBannerHandler;
            _getBannerByIdQueryHandler = getBannerByIdQueryHandler;
            _getBannerQueryHandler = getBannerQueryHandler;
            _removeBannerHandler = removeBannerHandler;
            _updateBannerHandler = updateBannerHandler;
        }
        [HttpGet]
        public async Task<IActionResult> ListBanner()
        {
            var values =await _getBannerQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBanner(int id)
        {
            var value =await _getBannerByIdQueryHandler.Handle(new GetBannerByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult>CreateBanner(CreateBannerCommand command)
        {
            await _createBannerHandler.Handle(command);
            return Ok("Banner bilgisi eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult>RemoveBanner(int id)
        {
            await _removeBannerHandler.Handle(new RemoveBannerCommand(id));
            return Ok("Banner bilgisi silindi");
        }
        [HttpPut]
        public async Task<IActionResult>UpdateBanner(UpdateBannerCommand command)
        {
            await _updateBannerHandler.Handle(command);
            return Ok("Banner bilgisi güncellendi");
        }
    }
}