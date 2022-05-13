using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace MoviesAPI.Migrations
{
    public partial class UpdatedonModelCreatingFKBug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cinemas_Addresses_CinemaId",
                table: "Cinemas");

            migrationBuilder.AlterColumn<int>(
                name: "CinemaId",
                table: "Cinemas",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.CreateIndex(
                name: "IX_Cinemas_AddressId",
                table: "Cinemas",
                column: "AddressId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cinemas_Addresses_AddressId",
                table: "Cinemas",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cinemas_Addresses_AddressId",
                table: "Cinemas");

            migrationBuilder.DropIndex(
                name: "IX_Cinemas_AddressId",
                table: "Cinemas");

            migrationBuilder.AlterColumn<int>(
                name: "CinemaId",
                table: "Cinemas",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_Cinemas_Addresses_CinemaId",
                table: "Cinemas",
                column: "CinemaId",
                principalTable: "Addresses",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
