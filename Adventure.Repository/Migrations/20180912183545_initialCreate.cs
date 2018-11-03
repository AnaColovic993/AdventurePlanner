using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Adventure.Repository.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdventureDetails_AdventureTypes_AdventureTypeId",
                table: "AdventureDetails");

            migrationBuilder.RenameColumn(
                name: "AdventureId",
                table: "AdventureDetails",
                newName: "AdventureDetailId");

            migrationBuilder.AlterColumn<string>(
                name: "AdventureTypeName",
                table: "AdventureTypes",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "AdventureTypeId",
                table: "AdventureDetails",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AdventureName",
                table: "AdventureDetails",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    QuestionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AskQuestion = table.Column<string>(nullable: true),
                    Answer = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.QuestionId);
                    table.ForeignKey(
                        name: "FK_Question_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAdventure",
                columns: table => new
                {
                    DateFrom = table.Column<DateTime>(nullable: false),
                    DateTo = table.Column<DateTime>(nullable: false),
                    PriceCalculated = table.Column<double>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    AdventureDetailId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAdventure", x => new { x.AdventureDetailId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserAdventure_AdventureDetails_AdventureDetailId",
                        column: x => x.AdventureDetailId,
                        principalTable: "AdventureDetails",
                        principalColumn: "AdventureDetailId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAdventure_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Question_UserId",
                table: "Question",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAdventure_UserId",
                table: "UserAdventure",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdventureDetails_AdventureTypes_AdventureTypeId",
                table: "AdventureDetails",
                column: "AdventureTypeId",
                principalTable: "AdventureTypes",
                principalColumn: "AdventureTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdventureDetails_AdventureTypes_AdventureTypeId",
                table: "AdventureDetails");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "UserAdventure");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.RenameColumn(
                name: "AdventureDetailId",
                table: "AdventureDetails",
                newName: "AdventureId");

            migrationBuilder.AlterColumn<string>(
                name: "AdventureTypeName",
                table: "AdventureTypes",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AdventureTypeId",
                table: "AdventureDetails",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "AdventureName",
                table: "AdventureDetails",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AdventureDetails_AdventureTypes_AdventureTypeId",
                table: "AdventureDetails",
                column: "AdventureTypeId",
                principalTable: "AdventureTypes",
                principalColumn: "AdventureTypeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
