using AutoMapper;
using DanderiNetwork.Core.Application.Interfaces.Repositories;
using DanderiNetwork.Core.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanderiNetwork.Core.Application.Services
{
    public class GenericService<SaveViewModel, ViewModel, Model> : IGenericService<SaveViewModel, ViewModel, Model>
        where SaveViewModel : class
        where ViewModel : class
        where Model : class
    {
        private readonly IGenericRepository<Model> _repository;
        private readonly IMapper _mapper;
        public GenericService(IGenericRepository<Model> repository, IMapper mapper) 
        { 
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<SaveViewModel> Add(SaveViewModel vm)
        {
            Model model = _mapper.Map<Model>(vm);

            model = await _repository.AddAsync(model);

            SaveViewModel modelVm = _mapper.Map<SaveViewModel>(model);

            return modelVm;
        }

        public async Task Update(SaveViewModel vm, int id)
        {
            Model model = _mapper.Map<Model>(vm);
            await _repository.UpdateAsync(model, id);
        }

        public async Task Delete(int id)
        {
            Model model = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(model);
        }

        public virtual async Task<List<ViewModel>> GetAllViewModel()
        {
            var modelList = await _repository.GetAllAsync();
            
            return _mapper.Map<List<ViewModel>>(modelList);
        }

        public async Task<SaveViewModel> GetByIdSaveViewModel(int id)
        {
            Model model = await _repository.GetByIdAsync(id);

            SaveViewModel vm = _mapper.Map<SaveViewModel>(model);

            return vm;
        }

    }
}
