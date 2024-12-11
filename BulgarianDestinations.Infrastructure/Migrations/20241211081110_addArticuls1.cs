using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulgarianDestinations.Infrastructure.Migrations
{
    public partial class addArticuls1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Articuls",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.InsertData(
                table: "Articuls",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "PersonId", "Price" },
                values: new object[] { 1, "Ръкавиците улавят различни дейности като ходене, бягане, колоездене и плуване. С детектор за движение разпознава Вашите промени в движението и  запаметява дейността Ви в.\r\nGarmin vivofit 3 ви подканва да се движите, като записва всяко ваше движение, включително и бездействие. След 1 час без движение червена лента на неактивност се появява на дисплея с лек сигнал. Червената светлина се увеличава на всеки 15 минути, докато не я изчистите, като се разходите в продължение на няколко минути.\r\nVívofit 3 следи Вашия напредък 24/7, благодарение на 1-годишен живот на батерията. Автоматично следи вашата почивка, докато спите. Той е устойчив на вода, така че да можете да го носите в басейна или под душа.", "https://i.ibb.co/0Dmhdz1/grivna.jpg", "Гривна GARMIN Vivofit 3", null, 143.00m });

            migrationBuilder.InsertData(
                table: "Articuls",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "PersonId", "Price" },
                values: new object[] { 2, "Комфортни термо ръкавици, изработени от стреч материя, ще ви осигурят чудесна защита от вятър и студ по време на активен спорт. Изработени от водоустойчива материя.\r\nПоказалецът е изработен от материя, проектирана за работа с GPS устройства, смартфони и всякакви тъчскрийни.", "https://i.ibb.co/q5K7mh6/rakavici.jpg", "Водоустойчиви термо ръкавици", null, 23.00m });

            migrationBuilder.InsertData(
                table: "Articuls",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "PersonId", "Price" },
                values: new object[] { 3, "Лесна и удобна за ползване крачна помпа.\r\nКрачна помпа, лесна за употреба.", "https://i.ibb.co/BqBxQxB/pompa.jpg", "Помпа CAO", null, 54.50m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articuls",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Articuls",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Articuls",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Articuls",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);
        }
    }
}
