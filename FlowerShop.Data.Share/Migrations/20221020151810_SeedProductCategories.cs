using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlowerShop.Data.Share.Migrations
{
    public partial class SeedProductCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO ""ProductCategories"" (""Title"",""Description"") VALUES('Комнатные цветы','Цветы в горшках, контейнерах для рассады')");
            migrationBuilder.Sql(@"INSERT INTO ""ProductCategories"" (""Title"",""Description"") VALUES('Букеты','Для праздников')");
            migrationBuilder.Sql(@"INSERT INTO ""ProductCategories"" (""Title"",""Description"") VALUES('Кактусы, суккуленты','Цветы в контейнерах для рассады')");
            migrationBuilder.Sql(@"INSERT INTO ""ProductCategories"" (""Title"",""Description"") VALUES('Букеты в шляпных коробках','Цветы в шляпной коробке предназначены для полива')");
            migrationBuilder.Sql(@"INSERT INTO ""ProductCategories"" (""Title"",""Description"") VALUES('Свадебный букет','Букеты для свадебной церемонии, букет невесты')");
 

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
