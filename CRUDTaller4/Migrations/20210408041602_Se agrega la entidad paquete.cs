using Microsoft.EntityFrameworkCore.Migrations;

namespace CRUDTaller4.Migrations
{
    public partial class Seagregalaentidadpaquete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Paquetes",
                columns: table => new
                {
                    PaqueteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<int>(nullable: false),
                    Peso = table.Column<int>(nullable: false),
                    CasilleroId = table.Column<int>(nullable: false),
                    EstadoId = table.Column<int>(nullable: false),
                    ImagenId = table.Column<int>(nullable: false),
                    TransportadoraId = table.Column<int>(nullable: false),
                    TipoMercanciaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paquetes", x => x.PaqueteId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Paquetes");
        }
    }
}
