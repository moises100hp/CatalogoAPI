using Catalogo.Domain.Entities;
using Catalogo.Domain.Interfaces;
using Catalogo.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.Infraestructure.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private ApplicationDbContext _categoryContext;

        public CategoriaRepository(ApplicationDbContext context)
        {
            _categoryContext = context;
        }

        public async Task<Categoria> CreateAsync(Categoria categoria)
        {
            _categoryContext.Add(categoria);
            await _categoryContext.SaveChangesAsync();
            return categoria;
        }

        public async Task<Categoria> GetByIdAsync(int? id)
        {
            return await _categoryContext.Categorias.FindAsync(id);
        }

        public async Task<IEnumerable<Categoria>> GetCategoriasAsync()
        {

            try
            {
                var categorias = await _categoryContext.Categorias.ToListAsync();
                return categorias;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Categoria> RemoveAsync(Categoria category)
        {
            _categoryContext.Remove(category);
            await _categoryContext.SaveChangesAsync();
            return category;
        }

        public async Task<Categoria> UpdateAsync(Categoria category)
        {
            _categoryContext.Update(category);
            await _categoryContext.SaveChangesAsync();
            return category;
        }
    }
}
