using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dpApp.Migrations
{
    public partial class AvaliacoesInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Avaliacao",
                columns: table => new
                {
                    AvaliacaoId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Ao1 = table.Column<int>(nullable: false),
                    Ao2 = table.Column<int>(nullable: false),
                    Ao2_1 = table.Column<int>(nullable: false),
                    Ao2_2 = table.Column<int>(nullable: false),
                    Ao3 = table.Column<int>(nullable: false),
                    Ao4 = table.Column<int>(nullable: false),
                    Ao5 = table.Column<int>(nullable: false),
                    Ao6 = table.Column<int>(nullable: false),
                    Ao7 = table.Column<int>(nullable: false),
                    Ao8 = table.Column<int>(nullable: false),
                    Ao9 = table.Column<int>(nullable: false),
                    Ao10 = table.Column<int>(nullable: false),
                    Ao11 = table.Column<int>(nullable: false),
                    Ao12 = table.Column<int>(nullable: false),
                    Ao13 = table.Column<int>(nullable: false),
                    Ao14 = table.Column<int>(nullable: false),
                    Ao15 = table.Column<int>(nullable: false),
                    Ao16 = table.Column<int>(nullable: false),
                    Ao17 = table.Column<int>(nullable: false),
                    Ao18 = table.Column<int>(nullable: false),
                    Ao19 = table.Column<int>(nullable: false),
                    Ao20 = table.Column<int>(nullable: false),
                    Ao21 = table.Column<int>(nullable: false),
                    Ao22 = table.Column<int>(nullable: false),
                    Ao23 = table.Column<int>(nullable: false),
                    Ao24 = table.Column<int>(nullable: false),
                    Ao25 = table.Column<int>(nullable: false),
                    Ao26 = table.Column<int>(nullable: false),
                    Ao27 = table.Column<int>(nullable: false),
                    Ao28 = table.Column<int>(nullable: false),
                    Ao29 = table.Column<int>(nullable: false),
                    Ao30 = table.Column<int>(nullable: false),
                    Ao31 = table.Column<int>(nullable: false),
                    Ao32 = table.Column<int>(nullable: false),
                    Ao33 = table.Column<int>(nullable: false),
                    Ao34 = table.Column<int>(nullable: false),
                    Ao35 = table.Column<int>(nullable: false),
                    Ao36 = table.Column<int>(nullable: false),
                    Ao37 = table.Column<int>(nullable: false),
                    Ao38 = table.Column<int>(nullable: false),
                    Ao39 = table.Column<int>(nullable: false),
                    Ao40 = table.Column<int>(nullable: false),
                    Ao41 = table.Column<int>(nullable: false),
                    Ao42 = table.Column<int>(nullable: false),
                    Ao43 = table.Column<int>(nullable: false),
                    Ao44 = table.Column<int>(nullable: false),
                    TipoAvaliacao = table.Column<string>(nullable: false),
                    Criada_em = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacao", x => x.AvaliacaoId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Avaliacao");
        }
    }
}
