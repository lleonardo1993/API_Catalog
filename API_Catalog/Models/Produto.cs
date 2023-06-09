﻿using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Catalog.Models
{
    [Table("Produtos")]
    public class Produto
    {

        [Key]
        public int ProdutoId { get; set; }
        
        [Required]
        [StringLength(80)]
        public string? Nome { get; set; }
        
        [Required]
        [StringLength(300)]
        public string? Descricao { get; set; }
        
        [Required]
        [Column(TypeName ="decimal(10,2)")]
        
        public decimal Preco { get; set; }
        public string? ImagemUrl { get; set; }
        public float Estoque { get; set; }
        public DateTime DataCadastro { get; set; }
        public int CategoriaId { get; set; }
        [JsonIgnore] // Propriedade Ignorada na Serialização e Deserialização ignora ex: end point post não precisa passar os dados da Categoria
        public Categoria? Categoria { get; set; }

    }
}
