using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aux_3d.Migrations
{
    /// <inheritdoc />
    public partial class PopularCategorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categorias(CategoriaNome, Descricao)" +
                                 "VALUES('Linha Action Figures','Action Figures em geral animes e estaturas de resinas')");
            migrationBuilder.Sql("INSERT INTO Categorias(CategoriaNome, Descricao)" +
                                 "VALUES('Linha Decoração','Decorações em geral e estaturas de resinas')");
            migrationBuilder.Sql("INSERT INTO Categorias(CategoriaNome, Descricao)" +
                                 "VALUES('Mais Vendidos','Relação dos itens mais vendidos')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categoria");
        }
    }
}
