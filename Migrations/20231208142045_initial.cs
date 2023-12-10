using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Slutuppgift___Bibliotek.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoanCards",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PinCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanCards", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISBN = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Availble = table.Column<bool>(type: "bit", nullable: false),
                    LoanTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    ReleaseYear = table.Column<int>(type: "int", nullable: false),
                    LoanCardID = table.Column<int>(type: "int", nullable: true),
                    AutherId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authers_AutherId",
                        column: x => x.AutherId,
                        principalTable: "Authers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Books_LoanCards_LoanCardID",
                        column: x => x.LoanCardID,
                        principalTable: "LoanCards",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    loanCardID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_LoanCards_loanCardID",
                        column: x => x.loanCardID,
                        principalTable: "LoanCards",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AutherId",
                table: "Books",
                column: "AutherId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_LoanCardID",
                table: "Books",
                column: "LoanCardID");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_loanCardID",
                table: "Customers",
                column: "loanCardID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Authers");

            migrationBuilder.DropTable(
                name: "LoanCards");
        }
    }
}
