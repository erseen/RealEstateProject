using AutoMapper;
using Emlak.Api.Entity;
using Emlak.Api.Identity;
using Emlak.Api.Models;
using Emlak.Api.Repository;
using Microsoft.EntityFrameworkCore;

namespace Emlak.Api.Service
{
    public class RealEstateManager : IRealEstateService
    {
        private readonly IRealEstateRepository _repository;
        private readonly IMapper _mapper;

        public RealEstateManager(IRealEstateRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<RealEstate> CreateAsync(RealEstate entity )
        {
            await _repository.AddAsync(entity);
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity != null) 
            { 
                await _repository.DeleteAsync(entity);
            }
        }

        public async Task<IEnumerable<RealEstate>> GetAllAsync()
        {
            return await _repository.GetAllAsync(); 
        }

        public async Task<RealEstate> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity != null) 
            { 
                return entity;
            }
            else
            {
                throw new Exception($"{id} not found");
            }
        }

        public async Task<IEnumerable<RealEstate>> GetRealEstateByName(string? title,int? floor,int? rooms,string? color)
        {

            using (var context = new ApplicationContext())
            {
                var result = context.RealEstates.AsQueryable();

                if (!string.IsNullOrWhiteSpace(title))
                {
                    result = result.Where(x => x.Title.ToLower().Contains(title.ToLower()));
                }
                if (color!="0")
                {

                if (!string.IsNullOrWhiteSpace(color))
                {
                    result = result.Where(x => x.Color.ToLower().Contains(color.ToLower()));
                }
                }

                if (floor!=0)
                {
                    result = result.Where(x => x.Floor == floor.Value);
                }

                if (rooms!=0)
                {
                    result = result.Where(x => x.Rooms == rooms.Value);
                }

                return await result.ToListAsync();
            }
        }

        public async Task<RealEstate> UpdateAsync( RealEstate entity)
        {
            await _repository.UpdateAsync(entity);
            return entity;

        }
    }
}
