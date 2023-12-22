using AutoMapper;
using Emlak.Api.Entity;
using Emlak.Api.Models;
using Emlak.Api.Repository;
using Emlak.Api.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Security.Cryptography.Xml;

namespace Emlak.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RealEstateController : ControllerBase
    {
        private readonly IRealEstateService _realEstateService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;


        public RealEstateController(IRealEstateService realEstateService, IMapper mapper, IWebHostEnvironment environment)
        {
            _realEstateService = realEstateService;
            _mapper = mapper;
            _environment = environment;
        }
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var entity = await _realEstateService.GetAllAsync();
            return Ok(entity);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] CreateRealEstateModel model)
        {

            //Bu yöntem solid'e aykırı fakat başka bir çözüm bulamadım.

            if (!ModelState.IsValid)
            {
                return BadRequest();


            }
            var entity = new RealEstate();

            if (model.RealEstateImageUrl != null)
            {
                var extension = Path.GetExtension(model.RealEstateImageUrl.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                model.RealEstateImageUrl.CopyTo(stream);

                entity.RealEstateImageUrl = newimagename;
            }
            entity.Price = model.Price;
            entity.Rooms = model.Rooms;
            entity.Type = model.Type;
            entity.Floor = model.Floor;
            entity.Color = model.Color;
            entity.Title = model.Title;
            entity.Desciption = model.Desciption;


            try
            {
                await _realEstateService.CreateAsync(entity);
                return Ok("Successfully Added ");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id)
        {
            await _realEstateService.DeleteAsync(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneByIdAsync([FromRoute(Name = "id")] int id)
        {

            var entity = await _realEstateService.GetByIdAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        [HttpGet("Search")]
        public async Task<IActionResult> SearchEstate(string? title, int? floor, int? rooms, string? color)
        {
        
            var entity= await _realEstateService.GetRealEstateByName(title,Convert.ToInt32(floor),Convert.ToInt32(rooms),color);
            return Ok(entity);
        }






        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute(Name = "id")] int id, [FromForm] UpdateRealEstateModel model)
        {
            ///Anti Solid
            var entity = await _realEstateService.GetByIdAsync(id);

            if (entity == null)
            {
                return NotFound();

            }
            entity.Price = model.Price;
            entity.Rooms = model.Rooms;
            entity.Type = model.Type;
            entity.Floor = model.Floor;
            entity.Color = model.Color;
            entity.Title = model.Title;
            entity.Desciption = model.Desciption;

                if (model.RealEstateImageUrl != null)
                {
                    var extension = Path.GetExtension(model.RealEstateImageUrl.FileName);
                    var newimagename = Guid.NewGuid() + extension;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", newimagename);
                    var stream = new FileStream(location, FileMode.Create);
                    model.RealEstateImageUrl.CopyTo(stream);
                    entity.RealEstateImageUrl = newimagename;
                }
               await _realEstateService.UpdateAsync(entity);
                return Ok(entity); 
        }
    }
}
