using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aux_3d.Migrations
{
    /// <inheritdoc />
    public partial class PopularProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Produtos(Nome, Descricao, DescricaoDetalhada, Preco, ImagemUrl, ImagemThumbnailUrl, IsProdutoPreferido, EmEstoque, CategoriaID)" +
                "VALUES ('Homem Aranha', 'Personagem de filme', 'Action Figure do personagem de filme homem aranha', 600.0, 'D:\\AUX3DSite\\Aux_3d\\Aux_3d\\wwwroot\\images\\ProdutosImg\\HomemAranha.jpeg','D:\\AUX3DSite\\Aux_3d\\Aux_3d\\wwwroot\\images\\ProdutosImg\\HomemAranha.gif', 1, 1, 1)");
            
            migrationBuilder.Sql("INSERT INTO Produtos(Nome, Descricao, DescricaoDetalhada, Preco, ImagemUrl, ImagemThumbnailUrl, IsProdutoPreferido, EmEstoque, CategoriaID)" +
                "VALUES ('Samurai', 'Personagem','Action Figure do personagem samurai com uma criança no colo', 350.0, 'D:\\AUX3DSite\\Aux_3d\\Aux_3d\\wwwroot\\images\\ProdutosImg\\Samurai.jpeg','D:\\AUX3DSite\\Aux_3d\\Aux_3d\\wwwroot\\images\\ProdutosImg\\Samurai.gif', 0, 1, 1)");
            
            migrationBuilder.Sql("INSERT INTO Produtos(Nome, Descricao, DescricaoDetalhada, Preco, ImagemUrl, ImagemThumbnailUrl, IsProdutoPreferido, EmEstoque, CategoriaID)" +
                "VALUES ('Mulher corpo em transformação', 'Decoração', 'Decoração de uma mulher que treina para queimar a gordura, corpo em transformação', 550.0, 'D:\\AUX3DSite\\Aux_3d\\Aux_3d\\wwwroot\\images\\ProdutosImg\\MulherTreinando.jpeg','D:\\AUX3DSite\\Aux_3d\\Aux_3d\\wwwroot\\images\\ProdutosImg\\MulherTreinando.jpeg', 1, 1, 2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Produtos");
        }
    }
}
