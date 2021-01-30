using ApiServer.Models;
using ApiServer.Models.Dto;
using ApiServer.Services;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiServer.Attributes;

namespace ApiServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ApiVersion("1.0")]
    public class BoilersController : ControllerBase
    {
        private readonly IBoilersListService boilersListService;

        public BoilersController(IBoilersListService boilersListService)
        {
            this.boilersListService = boilersListService;
        }

        [MyAuthorize]
        [HttpGet(Name = nameof(GetAll))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ResponseCache(CacheProfileName = "Static", VaryByQueryKeys = new[] {"offset", "limit"})]
        public async Task<ActionResult<PagedCollection<Boiler>>> GetAll([FromQuery]PagingOptions pagingOptions = null)
        {
            PagedResults<Boiler> list;

            if ((!pagingOptions.Offset.HasValue && !pagingOptions.Limit.HasValue))
            {
                list = await boilersListService.GetAsync();
            }
            else if(pagingOptions.Offset.HasValue && pagingOptions.Limit.HasValue)
            {
                list = await boilersListService.GetAsync(pagingOptions);
            }
            else
            {
                return BadRequest("Both or None of Limit and Offset parameters need to be passed" );
            }

            if (list == null)
            {
                return NotFound();
            }

            var collection = new PagedCollection<Boiler>()
            {
                Collection = list.Items.ToArray(),
                Limit = pagingOptions?.Limit ?? null,
                Offset = pagingOptions?.Offset ?? null,
                Size = list.TotalSize
            };

            return Ok(collection);
        }
    }
}
