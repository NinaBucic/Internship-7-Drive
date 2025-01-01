using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Drive.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password" },
                values: new object[,]
                {
                    { 1, "alice@gmail.com", "$2a$11$NA.uy5h1/kKDz39P02BlDuOg1K4RGY0u/8chuwa8mqPJ5Dwxo4toq" },
                    { 2, "bob@gmail.com", "$2a$11$5IMXWaVt4EbLN78tow4iguGudMaQNF2VX44WW0nsOc5RGkJRLc9Om" },
                    { 3, "charlie@gmail.com", "$2a$11$K3xBfB6SI3teTBqpujYEY.zdDr2lnXfOz426Y3kIoukfqtGizVy/q" },
                    { 4, "frane@gmail.com", "$2a$11$ipBvBnjYrK0J33U1V/kkQ.w1od/OX9aYYM87lJ6HbTIKzfuW6KtyK" }
                });

            migrationBuilder.InsertData(
                table: "Files",
                columns: new[] { "Id", "Content", "CreatedAt", "FolderId", "LastModifiedAt", "Name", "OwnerId" },
                values: new object[,]
                {
                    { 6, "File in root directory", new DateTime(2025, 1, 1, 22, 26, 54, 643, DateTimeKind.Utc).AddTicks(1983), null, new DateTime(2025, 1, 1, 22, 26, 54, 643, DateTimeKind.Utc).AddTicks(1984), "root_file_1.txt", 1 },
                    { 7, "File in root directory", new DateTime(2025, 1, 1, 22, 26, 54, 643, DateTimeKind.Utc).AddTicks(1987), null, new DateTime(2025, 1, 1, 22, 26, 54, 643, DateTimeKind.Utc).AddTicks(1989), "root_file_2.txt", 2 }
                });

            migrationBuilder.InsertData(
                table: "Folders",
                columns: new[] { "Id", "CreatedAt", "LastModified", "Name", "OwnerId", "ParentFolderId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 1, 22, 26, 54, 643, DateTimeKind.Utc).AddTicks(1688), new DateTime(2025, 1, 1, 22, 26, 54, 643, DateTimeKind.Utc).AddTicks(1691), "Work", 1, null },
                    { 2, new DateTime(2025, 1, 1, 22, 26, 54, 643, DateTimeKind.Utc).AddTicks(1729), new DateTime(2025, 1, 1, 22, 26, 54, 643, DateTimeKind.Utc).AddTicks(1730), "Personal", 2, null },
                    { 3, new DateTime(2025, 1, 1, 22, 26, 54, 643, DateTimeKind.Utc).AddTicks(1735), new DateTime(2025, 1, 1, 22, 26, 54, 643, DateTimeKind.Utc).AddTicks(1736), "Shared Folder", 1, null },
                    { 4, new DateTime(2025, 1, 1, 22, 26, 54, 643, DateTimeKind.Utc).AddTicks(1740), new DateTime(2025, 1, 1, 22, 26, 54, 643, DateTimeKind.Utc).AddTicks(1741), "Images", 3, null }
                });

            migrationBuilder.InsertData(
                table: "Files",
                columns: new[] { "Id", "Content", "CreatedAt", "FolderId", "LastModifiedAt", "Name", "OwnerId" },
                values: new object[,]
                {
                    { 1, "Work report content", new DateTime(2025, 1, 1, 22, 26, 54, 643, DateTimeKind.Utc).AddTicks(1931), 1, new DateTime(2025, 1, 1, 22, 26, 54, 643, DateTimeKind.Utc).AddTicks(1933), "report.docx", 1 },
                    { 2, null, new DateTime(2025, 1, 1, 22, 26, 54, 643, DateTimeKind.Utc).AddTicks(1949), 2, new DateTime(2025, 1, 1, 22, 26, 54, 643, DateTimeKind.Utc).AddTicks(1950), "photo.jpg", 2 },
                    { 3, "Collaborative notes", new DateTime(2025, 1, 1, 22, 26, 54, 643, DateTimeKind.Utc).AddTicks(1955), 3, new DateTime(2025, 1, 1, 22, 26, 54, 643, DateTimeKind.Utc).AddTicks(1956), "shared_notes.txt", 1 },
                    { 4, null, new DateTime(2025, 1, 1, 22, 26, 54, 643, DateTimeKind.Utc).AddTicks(1960), 4, new DateTime(2025, 1, 1, 22, 26, 54, 643, DateTimeKind.Utc).AddTicks(1961), "image1.png", 3 }
                });

            migrationBuilder.InsertData(
                table: "Folders",
                columns: new[] { "Id", "CreatedAt", "LastModified", "Name", "OwnerId", "ParentFolderId" },
                values: new object[] { 5, new DateTime(2025, 1, 1, 22, 26, 54, 643, DateTimeKind.Utc).AddTicks(1745), new DateTime(2025, 1, 1, 22, 26, 54, 643, DateTimeKind.Utc).AddTicks(1746), "Projects", 1, 1 });

            migrationBuilder.InsertData(
                table: "SharedItems",
                columns: new[] { "Id", "FileId", "FolderId", "OwnerId", "RecipientId" },
                values: new object[,]
                {
                    { 2, null, 3, 1, 3 },
                    { 3, null, 4, 3, 4 },
                    { 4, null, 2, 2, 1 },
                    { 5, 6, null, 1, 3 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "FileId", "LastModified" },
                values: new object[,]
                {
                    { 1, 2, "Looks good!", new DateTime(2025, 1, 1, 22, 26, 54, 643, DateTimeKind.Utc).AddTicks(2136), 1, new DateTime(2025, 1, 1, 22, 26, 54, 643, DateTimeKind.Utc).AddTicks(2138) },
                    { 2, 3, "Needs some changes.", new DateTime(2025, 1, 1, 22, 26, 54, 643, DateTimeKind.Utc).AddTicks(2160), 1, new DateTime(2025, 1, 1, 22, 26, 54, 643, DateTimeKind.Utc).AddTicks(2161) }
                });

            migrationBuilder.InsertData(
                table: "Files",
                columns: new[] { "Id", "Content", "CreatedAt", "FolderId", "LastModifiedAt", "Name", "OwnerId" },
                values: new object[] { 5, "Project tasks content", new DateTime(2025, 1, 1, 22, 26, 54, 643, DateTimeKind.Utc).AddTicks(1965), 5, new DateTime(2025, 1, 1, 22, 26, 54, 643, DateTimeKind.Utc).AddTicks(1967), "tasks.txt", 1 });

            migrationBuilder.InsertData(
                table: "SharedItems",
                columns: new[] { "Id", "FileId", "FolderId", "OwnerId", "RecipientId" },
                values: new object[] { 1, 3, null, 1, 2 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "FileId", "LastModified" },
                values: new object[] { 3, 4, "Great work!", new DateTime(2025, 1, 1, 22, 26, 54, 643, DateTimeKind.Utc).AddTicks(2165), 5, new DateTime(2025, 1, 1, 22, 26, 54, 643, DateTimeKind.Utc).AddTicks(2166) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "SharedItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SharedItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SharedItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SharedItems",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SharedItems",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
