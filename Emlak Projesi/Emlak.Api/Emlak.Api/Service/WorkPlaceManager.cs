using AutoMapper;
using Emlak.Api.Entity;
using Emlak.Api.Models;
using Emlak.Api.Repository;

namespace Emlak.Api.Service
{
    public class WorkPlaceManager : IWorkPlaceService
    {
        private readonly IWorkPlaceRepository _repository; 

        private readonly IMapper _mapper;

        public WorkPlaceManager(IMapper mapper, IWorkPlaceRepository repository)
        {

            _mapper = mapper;
            _repository = repository;
        }

        public async Task<WorkPlace> CreateAsync(CreateWorkPlaceModel model)
        {
            var entity = _mapper.Map<WorkPlace>(model);
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

        public async Task<IEnumerable<WorkPlace>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public  async Task<WorkPlace> GetByIdAsync(int id)
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

        public async Task<WorkPlace> UpdateAsync(UpdateWorkPlaceModel model)
        {
            var entity = await _repository.GetByIdAsync(model.Id);

            if (entity == null)
            {
                throw new Exception($"{model.Id} not found");
            }
            _mapper.Map(model, entity);
            await _repository.UpdateAsync(entity);
            return entity;
        }
    }
}
