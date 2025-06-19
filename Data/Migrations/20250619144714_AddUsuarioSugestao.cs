using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace pam.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUsuarioSugestao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_USUARIO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "Varchar(200)", maxLength: 200, nullable: false),
                    Senha = table.Column<string>(type: "Varchar(200)", maxLength: 200, nullable: false),
                    Telefone = table.Column<string>(type: "Varchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USUARIO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_SUGESTAO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "Varchar(200)", maxLength: 200, nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_SUGESTAO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_SUGESTAO_TB_USUARIO_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "TB_USUARIO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TB_USUARIO",
                columns: new[] { "Id", "Nome", "Senha", "Telefone" },
                values: new object[,]
                {
                    { 1, "João Silva", "senha123", "11999999999" },
                    { 2, "Maria Oliveira", "senha456", "11988888888" },
                    { 3, "Carlos Souza", "senha789", "11977777777" }
                });

            migrationBuilder.InsertData(
                table: "TB_SUGESTAO",
                columns: new[] { "Id", "Text", "UsuarioId" },
                values: new object[,]
                {
                    { 1, "Pedir Ifood", 1 },
                    { 2, "Ajuda no Uber", 1 },
                    { 3, "Logar no email", 2 },
                    { 4, "Mandar mensagem no Whatsapp", 3 },
                    { 5, "Navegar pelo Facebook", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_SUGESTAO_UsuarioId",
                table: "TB_SUGESTAO",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_SUGESTAO");

            migrationBuilder.DropTable(
                name: "TB_USUARIO");
        }
    }
}
