using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudCautus.Migrations
{
    /// <inheritdoc />
    public partial class InitialDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tb_Endereco",
                columns: table => new
                {
                    IdEndereco = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logradouro = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NumeroEndereco = table.Column<int>(type: "int", maxLength: 3, nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Endereco", x => x.IdEndereco);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Fornecedor",
                columns: table => new
                {
                    IdFornecedor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(130)", maxLength: 130, nullable: false),
                    RazaoSocial = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Fornecedor", x => x.IdFornecedor);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_Endereco");

            migrationBuilder.DropTable(
                name: "Tb_Fornecedor");
        }
    }
}
