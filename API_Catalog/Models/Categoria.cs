using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Catalog.Models;//novo recurso do .net6 não é preciso as chaves {} no namespace

[Table("Categorias")]//table e key, redundantes póis ja foram mapeados no context
public class Categoria
{    
    public Categoria()
    {
        Produtos = new Collection<Produto>();
    }
    [Key]
    public int CategoriaId { get; set; }
    [Required]
    [StringLength(80)]
    public string? Nome { get; set; }
    [Required]
    [StringLength(300)]
    public string? ImageUrl { get; set; }
    public ICollection<Produto>? Produtos { get; set; }
}
