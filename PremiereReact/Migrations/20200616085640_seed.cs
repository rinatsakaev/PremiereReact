using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PremiereReact.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Иван Васильевич меняет профессию" });

            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Приключения Электроника" });

            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Кавказская пленница" });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "Id", "FilmId", "StartTime" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 6, 16, 22, 35, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, new DateTime(2020, 6, 16, 19, 20, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 1, new DateTime(2020, 6, 16, 17, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 2, new DateTime(2020, 6, 17, 19, 20, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 2, new DateTime(2020, 6, 18, 19, 20, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
