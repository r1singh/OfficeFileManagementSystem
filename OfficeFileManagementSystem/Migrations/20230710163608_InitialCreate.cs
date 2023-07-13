using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OfficeFileManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "assignments",
                columns: table => new
                {
                    Assignment_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Employee_Id = table.Column<int>(type: "int", nullable: false),
                    Date_Allowed = table.Column<DateTime>(type: "Date", nullable: false),
                    Incoming_File_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assignments", x => x.Assignment_Id);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    Emp_Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Employee_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Employee_Designation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact_Number = table.Column<int>(type: "int", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.Emp_Id);
                });

            migrationBuilder.CreateTable(
                name: "importances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Days_Allowed = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_importances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "incomingFiles",
                columns: table => new
                {
                    Incoming_File_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date_Allowed = table.Column<DateTime>(type: "Date", nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Importance_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_incomingFiles", x => x.Incoming_File_Id);
                });

            migrationBuilder.CreateTable(
                name: "outgoingFiles",
                columns: table => new
                {
                    Out_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emp_Id = table.Column<int>(type: "int", nullable: false),
                    Incoming_File_Id = table.Column<int>(type: "int", nullable: false),
                    Date_Allowed = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_outgoingFiles", x => x.Out_Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "assignments");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "importances");

            migrationBuilder.DropTable(
                name: "incomingFiles");

            migrationBuilder.DropTable(
                name: "outgoingFiles");
        }
    }
}
