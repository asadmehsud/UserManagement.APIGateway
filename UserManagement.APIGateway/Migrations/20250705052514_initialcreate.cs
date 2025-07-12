using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UserManagement.APIGateway.Migrations
{
    /// <inheritdoc />
    public partial class initialcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Otp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "City", "Contact", "Country", "Email", "FirstName", "Image", "LastName", "Otp", "PasswordHash", "PasswordSalt", "Role", "UserName" },
                values: new object[,]
                {
                    { new Guid("44e59eb2-dcf3-4824-9b91-9e82c7a757d4"), "DDA", "Dikhan", "03429765706", "Pakistan", "asad@gmail.com", "Asad", "image", "Khan", "123", new byte[0], new byte[0], 0, "asad_1" },
                    { new Guid("73bcf899-bee3-4f95-8f7d-bbdaa1aa53ff"), "Haji Abad", "FaisalAbad", "03334566430", "Pakistan", "faizan@gmail.com", "Faizan", "image", "Ahmed", "111", new byte[0], new byte[0], 0, "fazan_0" },
                    { new Guid("937f789f-5bdf-43d0-8e62-912743264f85"), "Tank Ada", "Dikhan", "03457788900", "Pakistan", "ali@gmail.com", "Ali", "image", "Khan", "009", new byte[0], new byte[0], 1, "ali_2" },
                    { new Guid("c7601d97-7cf8-4057-a53f-6500209e6083"), "Korangi", "Karachi", "03001002001", "Pakistan", "alya@gmail.com", "Alya", "image", "Khan", "333", new byte[0], new byte[0], 1, "alya_9" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
