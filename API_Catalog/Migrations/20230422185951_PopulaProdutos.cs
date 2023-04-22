using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Catalog.Migrations
{
    /// <inheritdoc />
    public partial class PopulaProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Produtos(Nome,Descricao,Preco,ImagemUrl,Estoque,DataCadastro,CategoriaId) " + "Values('Coca-cola-diet', 'Regrigerante','5.43','coca-cola.jpg',50,CURRENT_TIMESTAMP,2)");

            mb.Sql("Insert into Produtos(Nome,Descricao,Preco,ImagemUrl,Estoque,DataCadastro,CategoriaId) " + "Values('Lanche-de-atum', 'lanche','5.43','Lanche-de-atum.jpg',50,CURRENT_TIMESTAMP,3)");

            mb.Sql("Insert into Produtos(Nome,Descricao,Preco,ImagemUrl,Estoque,DataCadastro,CategoriaId) " + "Values('Pudim', 'sobremesa','5.43','Pudim.jpg',50,CURRENT_TIMESTAMP,4)");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Produtos");
        }
    }
}
