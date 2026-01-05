using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookstoreApplication.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "PublishedDate",
                table: "Books",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Birthday",
                table: "Author",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "Id", "Biography", "Birthday", "FullName" },
                values: new object[,]
                {
                    { 1, "British author", new DateTime(1965, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "J.K. Rowling" },
                    { 2, "American novelist", new DateTime(1948, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "George R.R. Martin" },
                    { 3, "English writer", new DateTime(1890, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Agatha Christie" },
                    { 4, "British writer", new DateTime(1892, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "J.R.R. Tolkien" },
                    { 5, "American author", new DateTime(1947, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stephen King" }
                });

            migrationBuilder.InsertData(
                table: "Awards",
                columns: new[] { "Id", "Description", "Name", "Year" },
                values: new object[,]
                {
                    { 1, "Top fiction award", "Best Fiction", 2000 },
                    { 2, "Voted by readers", "Reader's Choice", 2005 },
                    { 3, "Lifetime award", "Lifetime Achievement", 2010 },
                    { 4, "Award for best novel", "Best Novel", 2020 }
                });

            migrationBuilder.InsertData(
                table: "Publisher",
                columns: new[] { "Id", "Address", "Name", "Website" },
                values: new object[,]
                {
                    { 1, "London", "Penguin Books", "www.penguin.com" },
                    { 2, "New York", "HarperCollins", "www.harpercollins.com" },
                    { 3, "New York", "Random House", "www.randomhouse.com" }
                });

            migrationBuilder.InsertData(
                table: "AuthorAwardBridge",
                columns: new[] { "Id", "AuthorId", "AwardId", "YearAward" },
                values: new object[,]
                {
                    { 1, 1, 1, 2000 },
                    { 2, 1, 2, 2005 },
                    { 3, 2, 1, 2000 },
                    { 4, 2, 4, 2020 },
                    { 5, 3, 3, 2010 },
                    { 6, 3, 2, 2005 },
                    { 7, 4, 4, 2020 },
                    { 8, 4, 1, 2000 },
                    { 9, 5, 2, 2005 },
                    { 10, 5, 4, 2020 },
                    { 11, 1, 4, 2020 },
                    { 12, 2, 2, 2005 },
                    { 13, 3, 1, 2000 },
                    { 14, 4, 2, 2005 },
                    { 15, 5, 3, 2010 }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "ISBN", "PageCount", "PublishedDate", "PublisherId", "Title" },
                values: new object[,]
                {
                    { 1, 1, "9780747532699", 320, new DateTime(1997, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Harry Potter 1" },
                    { 2, 1, "9780747538493", 341, new DateTime(1998, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Harry Potter 2" },
                    { 3, 2, "9780553103540", 694, new DateTime(1996, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "A Game of Thrones" },
                    { 4, 2, "9780553108033", 768, new DateTime(1998, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "A Clash of Kings" },
                    { 5, 3, "9780007119318", 256, new DateTime(1934, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Murder on the Orient Express" },
                    { 6, 3, "9780062073488", 272, new DateTime(1939, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "And Then There Were None" },
                    { 7, 4, "9780547928227", 310, new DateTime(1937, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "The Hobbit" },
                    { 8, 4, "9780544003415", 1178, new DateTime(1954, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "The Lord of the Rings" },
                    { 9, 5, "9780385121675", 447, new DateTime(1977, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "The Shining" },
                    { 10, 5, "9781501142970", 1138, new DateTime(1986, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "It" },
                    { 11, 5, "9780385086953", 199, new DateTime(1974, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Carrie" },
                    { 12, 1, "9780439321600", 128, new DateTime(2001, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Fantastic Beasts" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Awards",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Awards",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Awards",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Awards",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublishedDate",
                table: "Books",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Birthday",
                table: "Author",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");
        }
    }
}
