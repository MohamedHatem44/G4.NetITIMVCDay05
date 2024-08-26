using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace G4.NetITIMVCDay05.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "HR" },
                    { 2, "PR" },
                    { 3, "Social Media" },
                    { 4, "Finance" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "Age", "DepartmentId", "Email", "Name", "Password", "Salary" },
                values: new object[,]
                {
                    { 1, "Ismailia", 22, 1, "email@mail.com", "Ramy", "123456", 1234m },
                    { 2, "Ismailia", 32, 2, "email@mail.com", "Mai", "123456", 2234m },
                    { 3, "Ismailia", 42, 3, "email@mail.com", "Ali", "123456", 3234m },
                    { 4, "Ismailia", 52, 4, "email@mail.com", "Omar", "123456", 4234m },
                    { 5, "Ismailia", 28, 1, "email@mail.com", "Mostafa", "123456", 5234m },
                    { 6, "Ismailia", 38, 2, "email@mail.com", "Ahmed", "123456", 6234m },
                    { 7, "Ismailia", 48, 3, "email@mail.com", "Sara", "123456", 7234m },
                    { 8, "Ismailia", 26, 4, "email@mail.com", "Osama", "123456", 8234m },
                    { 9, "Ismailia", 36, 1, "email@mail.com", "Mohamed", "123456", 9234m },
                    { 10, "Ismailia", 46, 2, "email@mail.com", "Nour", "123456", 10234m },
                    { 11, "Ismailia", 46, 3, "email@mail.com", "Mohamed", "123456", 10234m },
                    { 12, "Ismailia", 46, 4, "email@mail.com", "Nour", "123456", 10234m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
