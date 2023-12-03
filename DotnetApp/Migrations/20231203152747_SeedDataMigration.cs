using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DotnetApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerMovie_Movies_Moviesid",
                table: "CustomerMovie");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Movies",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Moviesid",
                table: "CustomerMovie",
                newName: "MoviesId");

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "GenreName" },
                values: new object[,]
                {
                    { new Guid("79e6f638-d7e7-4f63-8365-f172cb925381"), "GenreFromJsonFile2" },
                    { new Guid("84ca0bcd-082c-49cb-aa77-ea2f1f5f8285"), "GenreFromJsonFile1" }
                });

            migrationBuilder.InsertData(
                table: "Membershiptypes",
                columns: new[] { "Id", "DiscountRate", "DurationInMonths", "Name", "SignUpFee" },
                values: new object[,]
                {
                    { new Guid("84ca0bcd-082c-49cb-aa77-ea2f1f5f8281"), 0.050000000000000003, 0, "offre normale", 0.0 },
                    { new Guid("84ca0bcd-082c-49cb-aa77-ea2f1f5f8685"), 0.20000000000000001, 0, "offre premium", 0.0 },
                    { new Guid("84ca0bcd-082c-49cb-aa77-ea2f1f5f9285"), 0.10000000000000001, 0, "offre moyenne", 0.0 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerMovie_Movies_MoviesId",
                table: "CustomerMovie",
                column: "MoviesId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerMovie_Movies_MoviesId",
                table: "CustomerMovie");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("79e6f638-d7e7-4f63-8365-f172cb925381"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("84ca0bcd-082c-49cb-aa77-ea2f1f5f8285"));

            migrationBuilder.DeleteData(
                table: "Membershiptypes",
                keyColumn: "Id",
                keyValue: new Guid("84ca0bcd-082c-49cb-aa77-ea2f1f5f8281"));

            migrationBuilder.DeleteData(
                table: "Membershiptypes",
                keyColumn: "Id",
                keyValue: new Guid("84ca0bcd-082c-49cb-aa77-ea2f1f5f8685"));

            migrationBuilder.DeleteData(
                table: "Membershiptypes",
                keyColumn: "Id",
                keyValue: new Guid("84ca0bcd-082c-49cb-aa77-ea2f1f5f9285"));

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Movies",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "MoviesId",
                table: "CustomerMovie",
                newName: "Moviesid");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerMovie_Movies_Moviesid",
                table: "CustomerMovie",
                column: "Moviesid",
                principalTable: "Movies",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
