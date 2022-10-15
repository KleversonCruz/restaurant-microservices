using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Core.Requests;

namespace Restaurants.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private ISender _mediator = null!;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

        [HttpGet()]
        public Task<List<RestaurantDto>> GetListAsync()
        {
            return Mediator.Send(new GetAllRestaurantsRequest());
        }

        [HttpGet("{id:guid}")]
        public Task<RestaurantDto> GetAsync(Guid id)
        {
            return Mediator.Send(new GetRestaurantRequest(id));
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync(CreateRestaurantRequest request)
        {
            var id = await Mediator.Send(request);
            return CreatedAtAction(nameof(GetAsync), new { id }, id);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateAsync(UpdateRestaurantRequest request, Guid id)
        {
            return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            await Mediator.Send(new DeleteRestaurantRequest(id));
            return NoContent();
        }
    }
}
