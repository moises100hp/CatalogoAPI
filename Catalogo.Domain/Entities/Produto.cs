using Catalogo.Domain.Validation;

namespace Catalogo.Domain.Entities
{
    public sealed class Produto : Entity
    {
        public Produto()
        {
            
        }

        public Produto(string Nome, string descricao, decimal preco, string ImagemUrl,
            int estoque, DateTime dataCadastro)
        {
            ValidateDomain(Nome, descricao, preco, ImagemUrl, estoque, dataCadastro);
        }

        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal Preco { get; private set; }
        public string ImagemUrl { get; private set; }
        public int Estoque { get; private set; }
        public DateTime DataCadastro { get; private set; }

        public void Update(string nome, string descricao, decimal preco, string ImagemUrl,
            int estoque, DateTime dataCadastro, int categoriaId)
        {
            ValidateDomain(nome, descricao, preco, ImagemUrl, estoque, dataCadastro);
            CategoriaId = categoriaId;
        }

        private void ValidateDomain(string nome, string descricao, decimal preco, string ImagemUrl, 
            int estoque, DateTime dataCadastro)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome),
                "Nome inválido. O nome é obrigatório");

            DomainExceptionValidation.When(nome.Length < 3,
                "O nome deve ter no mínimo 3 caracteres");

            DomainExceptionValidation.When(string.IsNullOrEmpty(descricao),
                "Descrição inválida. A descrição é obrigatória");

            DomainExceptionValidation.When(descricao.Length < 5,
                "A descrição deve ter no mínimo 5 caracteres");

            DomainExceptionValidation.When(preco < 0, "Valor do preço inválido");

            DomainExceptionValidation.When(ImagemUrl?.Length > 250,
                "O nome da imagem não pode exceder 250 caracteres");

            DomainExceptionValidation.When(preco < 0, "Valor do preço inváido");

            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            this.ImagemUrl = ImagemUrl;
            Estoque = estoque;
            DataCadastro = dataCadastro;
        }

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
