using Catalogo.Domain.Entities;
using Catalogo.Domain.Interfaces;

namespace Catalogo.Infraestructure.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        public Task<Produto> CreateAsync(Produto product)
        {
            throw new NotImplementedException();
        }

        public Task<Produto> GetByIdAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Produto>> GetProdutoAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Produto> RemoveAsync(Produto product)
        {
            throw new NotImplementedException();
        }

        public Task<Produto> UpdateAsync(Produto product)
        {
            throw new NotImplementedException();
        }
    }
}
