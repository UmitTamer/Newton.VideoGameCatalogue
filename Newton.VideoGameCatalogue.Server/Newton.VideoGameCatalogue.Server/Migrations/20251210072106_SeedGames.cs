using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Newton.VideoGameCatalogue.Server.Migrations
{
    /// <inheritdoc />
    public partial class SeedGames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Genre", "Rating", "ReleaseYear", "Title" },
                values: new object[,]
                {
                    { 1, "Strategy", 8.8000000000000007, 2006, "Total War: MEDIEVAL II" },
                    { 2, "Strategy", 8.4000000000000004, 2019, "Age of Empires II: Definitive Edition" },
                    { 3, "Survival", 6.4000000000000004, 2020, "Ancestors: The Humankind Odyssey" },
                    { 4, "RPG", 8.0, 2011, "Assassin's Creed Revelations" },
                    { 5, "RPG", 7.2000000000000002, 2019, "Assassin's Creed III Remastered" },
                    { 6, "RPG", 8.3000000000000007, 2018, "Assassin's Creed Odyssey" },
                    { 7, "RPG", 8.3000000000000007, 2017, "Assassin's Creed Origins" },
                    { 8, "FPS", 9.8000000000000007, 2003, "Call of Duty (2003)" },
                    { 9, "Board Game", 6.0999999999999996, 2017, "Catan Universe" },
                    { 10, "Strategy", 8.5, 2015, "Cities Skylines" },
                    { 11, "RPG", 8.5999999999999996, 2020, "Cyberpunk 2077" },
                    { 12, "Story", 7.7999999999999998, 2018, "Detroit: Become Human" },
                    { 13, "RPG", 8.4000000000000004, 2016, "The Elder Scrolls V: Skyrim Special Edition" },
                    { 14, "Strategy", 8.6999999999999993, 2013, "Europa Universalis IV" },
                    { 15, "Fighting", 7.7999999999999998, 2017, "FOR HONOR" },
                    { 16, "Open World", 9.6999999999999993, 2001, "Grand Theft Auto III" },
                    { 17, "Open World", 9.5, 2004, "Grand Theft Auto: San Andreas" },
                    { 18, "Open World", 9.5, 2002, "Grand Theft Auto: Vice City" },
                    { 19, "Strategy", 8.3000000000000007, 2015, "Kingdom: Classic" },
                    { 20, "RPG", 8.8000000000000007, 2025, "Kingdom Come: Deliverance II" },
                    { 21, "Puzzle", 8.5999999999999996, 2015, "Mini Metro" },
                    { 22, "Puzzle", 8.6999999999999993, 2021, "Mini Motorways" },
                    { 23, "Strategy", 7.7000000000000002, 2022, "Mount & Blade II: Bannerlord" },
                    { 24, "Strategy", 8.5, 2019, "Oxygen Not Included" },
                    { 25, "Puzzle", 9.0, 2007, "Portal" },
                    { 26, "Puzzle", 9.5, 2011, "Portal 2" },
                    { 27, "Action", 6.9000000000000004, 2020, "Raji: An Ancient Epic" },
                    { 28, "Souls-like", 9.0, 2019, "Sekiro: Shadows Die Twice" },
                    { 29, "Strategy", 8.8000000000000007, 2016, "Sid Meier's Civilization VI" },
                    { 30, "Puzzle", 8.3000000000000007, 2022, "Stray" },
                    { 31, "FPS", 9.1999999999999993, 2018, "Totally Accurate Battlegrounds" },
                    { 32, "RPG", 9.1999999999999993, 2015, "The Witcher 3: Wild Hunt" },
                    { 33, "Strategy", 8.6999999999999993, 2000, "Zeus: Master of Olympus" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 33);
        }
    }
}
