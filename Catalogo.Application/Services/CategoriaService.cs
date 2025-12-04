using AutoMapper;
using Catalogo.Application.DTOs;
using Catalogo.Application.Interfaces;
using Catalogo.Domain.Entities;
using Catalogo.Domain.Interfaces;

namespace Catalogo.Application.Services
{
    public class CategoriaService : ICategoriaService
    {
        private ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;

        public CategoriaService(ICategoriaRepository categoriaRepository, 
                                IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoriaDTO>> GetCategorias()
        {
            var categoriesEntity = await _categoriaRepository.GetCategoriasAsync();
            return _mapper.Map<IEnumerable<CategoriaDTO>>(categoriesEntity);
        }

        public async Task<CategoriaDTO> GetById(int? id)
        {
            var categoryEntity = await _categoriaRepository.GetByIdAsync(id);
            return _mapper.Map<CategoriaDTO>(categoryEntity);
        }

        public async Task Add(CategoriaDTO categoryDTO)
        {
            var categoryEntity = _mapper.Map<Categoria>(categoryDTO);
            await _categoriaRepository.CreateAsync(categoryEntity);
        }

        public async Task Update(CategoriaDTO categoryDTO)
        {
            var categoryEntity = _mapper.Map<Categoria>(categoryDTO);
            await _categoriaRepository.UpdateAsync(categoryEntity);
        }

        public async Task Remove(int? id)
        {
            var categoryEntity = _categoriaRepository.GetByIdAsync(id).Result;
            await _categoriaRepository.RemoveAsync(categoryEntity);
        }
    }
}
