using AutoMapper;
using Emlak.Api.Models;
using Emlak.Api.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Emlak.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class WorkPlaceController : ControllerBase
    {
        private readonly IWorkPlaceService _workPlaceService;
        private readonly IMapper _mapper;

        public WorkPlaceController(IWorkPlaceService workPlaceService, IMapper mapper)
        {
            _workPlaceService = workPlaceService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var entity = await _workPlaceService.GetAllAsync();
            return Ok(entity);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateWorkPlaceModel model)
        {
            await _workPlaceService.CreateAsync(model);
            return Ok(model);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id)
        {
            await _workPlaceService.DeleteAsync(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneByIdAsync([FromRoute(Name = "id")] int id)
        {

            var entity = await _workPlaceService.GetByIdAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateWorkPlaceModel model)
        {
            var entity = await _workPlaceService.GetByIdAsync(model.Id);
            if (model is null)
            {
                return NotFound();
            }
            if (entity == null)
            {
                return NotFound();
            }

            await _workPlaceService.UpdateAsync(model);

            return Ok(model);
        }



    }
}
