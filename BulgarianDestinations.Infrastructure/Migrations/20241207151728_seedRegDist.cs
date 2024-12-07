using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulgarianDestinations.Infrastructure.Migrations
{
    public partial class seedRegDist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Благоевград" },
                    { 2, "Бургас" },
                    { 3, "Варна" },
                    { 4, "Велико Търново" },
                    { 5, "Видин" },
                    { 6, "Враца" },
                    { 7, "Габрово" },
                    { 8, "Добрич" },
                    { 9, "Кърджали" },
                    { 10, "Кюстендил" },
                    { 11, "Ловеч" },
                    { 12, "Монтана" },
                    { 13, "Пазарджик" },
                    { 14, "Перник" },
                    { 15, "Плевен" },
                    { 16, "Пловдив" },
                    { 17, "Разград" },
                    { 18, "Русе" },
                    { 19, "Силистра" },
                    { 20, "Сливен" },
                    { 21, "Смолян" },
                    { 22, "София - Град" },
                    { 23, "София - Област" },
                    { 24, "Стара Загора" },
                    { 25, "Търговище" },
                    { 26, "Хасково" },
                    { 27, "Шумен" },
                    { 28, "Ямбол" }
                });

            migrationBuilder.InsertData(
                table: "Destination",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "PersonId", "RegionId" },
                values: new object[] { 1, "Къщата на Баба Ванга в местността Рупите е била мястото, където известната българска пророчица е приемала нуждаещите се. Малката къщичка се намира на територията на новопострения манастирския комплекс около храма на Ванга. През прозорчетата могат да да се види подредбата на стаите, мебели и вещи на Пророчицата.", "https://i.ibb.co/Q6wvBfd/rupite.jpg", "Рупите - Къщата на Ванга", null, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Destination",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
