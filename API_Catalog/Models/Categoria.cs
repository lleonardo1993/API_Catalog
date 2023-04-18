using System.Collections.ObjectModel;

namespace API_Catalog.Models;//novo recurso do .net6 não é preciso as chaves {} no namespace

public class Categoria
{

    public Categoria()
    {
        Produtos = new Collection<Produto>();
    }

    public int CategoriaId { get; set; }
    public string? Nome { get; set; }
    public string? ImageUrl { get; set; }
    public ICollection<Produto>? Produtos { get; set; }
}
