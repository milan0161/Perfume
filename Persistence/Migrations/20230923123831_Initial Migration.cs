using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Perfumes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Volume = table.Column<float>(type: "real", nullable: false),
                    Scent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfumes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Perfumes",
                columns: new[] { "Id", "Brand", "ImageUrl", "Name", "Scent", "Volume" },
                values: new object[,]
                {
                    { 1, "Goyette Group", "https://loremflickr.com/320/240?lock=1983928920", "Leland", "Diesel", 110f },
                    { 2, "Cartwright Group", "https://loremflickr.com/320/240?lock=115213802", "Maynard", "Electric", 110f },
                    { 3, "Bosco - Lindgren", "https://loremflickr.com/320/240?lock=612004936", "Annabell", "Diesel", 110f },
                    { 4, "Wilkinson, Quigley and Bailey", "https://loremflickr.com/320/240?lock=928533423", "Jarrod", "Gasoline", 110f },
                    { 5, "Stiedemann, Schmitt and Baumbach", "https://loremflickr.com/320/240?lock=1104687252", "Erling", "Hybrid", 110f },
                    { 6, "Gulgowski Inc", "https://loremflickr.com/320/240?lock=375193409", "Mylene", "Hybrid", 110f },
                    { 7, "Ankunding, Barton and Reilly", "https://loremflickr.com/320/240?lock=2076023217", "Amya", "Diesel", 110f },
                    { 8, "Reichel - Bashirian", "https://loremflickr.com/320/240?lock=1424085822", "Ansley", "Diesel", 110f },
                    { 9, "Kuhlman Inc", "https://loremflickr.com/320/240?lock=541003444", "Graham", "Diesel", 110f },
                    { 10, "Schiller, Wuckert and Hintz", "https://loremflickr.com/320/240?lock=851757316", "Dominic", "Diesel", 110f },
                    { 11, "Wunsch Inc", "https://loremflickr.com/320/240?lock=2117482831", "Abbie", "Electric", 110f },
                    { 12, "Bauch, Kilback and McCullough", "https://loremflickr.com/320/240?lock=710013855", "Robyn", "Gasoline", 110f },
                    { 13, "Wilderman - Denesik", "https://loremflickr.com/320/240?lock=1268119113", "Kelly", "Diesel", 110f },
                    { 14, "Hills, Effertz and O'Conner", "https://loremflickr.com/320/240?lock=1185053379", "Vernon", "Electric", 110f },
                    { 15, "Tremblay - Metz", "https://loremflickr.com/320/240?lock=1533243116", "Sophie", "Hybrid", 110f },
                    { 16, "Wyman - Swift", "https://loremflickr.com/320/240?lock=1924139421", "Clay", "Gasoline", 110f },
                    { 17, "Hodkiewicz - Lindgren", "https://loremflickr.com/320/240?lock=206837662", "Kris", "Hybrid", 110f },
                    { 18, "Simonis and Sons", "https://loremflickr.com/320/240?lock=2113060062", "Bridgette", "Diesel", 110f },
                    { 19, "Pacocha and Sons", "https://loremflickr.com/320/240?lock=857757327", "Alanis", "Hybrid", 110f },
                    { 20, "Wiza Group", "https://loremflickr.com/320/240?lock=1776116011", "Annabelle", "Diesel", 110f }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Perfumes");
        }
    }
}
