using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Adventure.Repository.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdventureTypes",
                columns: table => new
                {
                    AdventureTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdventureTypeName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdventureTypes", x => x.AdventureTypeId);
                });

            migrationBuilder.CreateTable(
                name: "AdventureDetails",
                columns: table => new
                {
                    AdventureId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdventureName = table.Column<string>(nullable: false),
                    PricePerDay = table.Column<double>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    AdventureTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdventureDetails", x => x.AdventureId);
                    table.ForeignKey(
                        name: "FK_AdventureDetails_AdventureTypes_AdventureTypeId",
                        column: x => x.AdventureTypeId,
                        principalTable: "AdventureTypes",
                        principalColumn: "AdventureTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdventureDetails_AdventureTypeId",
                table: "AdventureDetails",
                column: "AdventureTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdventureDetails");

            migrationBuilder.DropTable(
                name: "AdventureTypes");
        }
    }
}
