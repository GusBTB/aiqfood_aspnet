using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LanchesMac.Migrations
{
    /// <inheritdoc />
    public partial class PopularLanches : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Lanches(CategoriaId,DescricaoCurta,DescricaoDetalhada,EmEstoque,ImagemThumbnailUrl,ImagemUrl,IsLanchePreferido,Nome,Preco) VALUES(1,'Pão, hambúrger, ovo, presunto, queijo e batata palha', 'Delicioso lanche...', 1, 'https://luallanches.com.br/wp-content/uploads/2019/12/lanche07.jpg', 'https://luallanches.com.br/wp-content/uploads/2019/12/lanche07.jpg', 0, 'Beirute', 150.0)");
            migrationBuilder.Sql("INSERT INTO Lanches(CategoriaId,DescricaoCurta,DescricaoDetalhada,EmEstoque,ImagemThumbnailUrl,ImagemUrl,IsLanchePreferido,Nome,Preco) VALUES(1,'Pão, queijo gorgonzas, camarão e batata palha', 'Receita da mãe', 1, 'https://conteudo.solutudo.com.br/wp-content/uploads/2020/04/lanches-rapidos-1.jpg', 'https://conteudo.solutudo.com.br/wp-content/uploads/2020/04/lanches-rapidos-1.jpg', 1, 'Hard rock', 250.0)");
            migrationBuilder.Sql("INSERT INTO Lanches(CategoriaId,DescricaoCurta,DescricaoDetalhada,EmEstoque,ImagemThumbnailUrl,ImagemUrl,IsLanchePreferido,Nome,Preco) VALUES(2,'Pão, chifre de galinha com creme de polenguinho', 'Melhor da casa', 1, 'https://www.revendedor.com.br/wp-content/uploads/2021/06/ideias-de-lanches-para-delivery-scaled.jpeg', 'https://www.revendedor.com.br/wp-content/uploads/2021/06/ideias-de-lanches-para-delivery-scaled.jpeg', 0, 'Meio pá', 3.0)");
            migrationBuilder.Sql("INSERT INTO Lanches(CategoriaId,DescricaoCurta,DescricaoDetalhada,EmEstoque,ImagemThumbnailUrl,ImagemUrl,IsLanchePreferido,Nome,Preco) VALUES(2,'Pão, vômito de cachorro com mussarela', 'Recomendo...', 1, 'https://segredosdacomida.com.br/wp-content/uploads/2022/12/Lanche-da-tarde-de-pobre.jpg', 'https://segredosdacomida.com.br/wp-content/uploads/2022/12/Lanche-da-tarde-de-pobre.jpg', 1, 'Grande coisa', 20.0)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Lanches");
        }
    }
}
