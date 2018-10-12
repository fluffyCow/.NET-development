using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EnvironmentCrime_4.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<string>(nullable: false),
                    DepartmentName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "ErrandStatuses",
                columns: table => new
                {
                    StatusId = table.Column<string>(nullable: false),
                    StatusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrandStatuses", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "Pictures",
                columns: table => new
                {
                    PictureId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PictureName = table.Column<string>(nullable: true),
                    ErrandId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pictures", x => x.PictureId);
                });

            migrationBuilder.CreateTable(
                name: "Samples",
                columns: table => new
                {
                    SampleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SampleName = table.Column<string>(nullable: true),
                    ErrandId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Samples", x => x.SampleId);
                });

            migrationBuilder.CreateTable(
                name: "Sequences",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CurrentValue = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sequences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<string>(nullable: false),
                    EmployeeName = table.Column<string>(nullable: false),
                    RoleTitle = table.Column<string>(nullable: true),
                    DepartmentId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Errands",
                columns: table => new
                {
                    ErrandID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RefNumber = table.Column<string>(nullable: true),
                    Place = table.Column<string>(nullable: false),
                    TypeOfCrime = table.Column<string>(nullable: false),
                    DateOfObservation = table.Column<DateTime>(nullable: false),
                    Observation = table.Column<string>(nullable: true),
                    InvestigatorAction = table.Column<string>(nullable: true),
                    InvestigatorInfo = table.Column<string>(nullable: true),
                    InformerName = table.Column<string>(nullable: false),
                    InformerPhone = table.Column<string>(nullable: false),
                    StatusId = table.Column<string>(nullable: true),
                    DepartmentId = table.Column<string>(nullable: true),
                    EmployeeId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Errands", x => x.ErrandID);
                    table.ForeignKey(
                        name: "FK_Errands_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Errands_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Errands_ErrandStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "ErrandStatuses",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Errands_DepartmentId",
                table: "Errands",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Errands_EmployeeId",
                table: "Errands",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Errands_StatusId",
                table: "Errands",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Errands");

            migrationBuilder.DropTable(
                name: "Pictures");

            migrationBuilder.DropTable(
                name: "Samples");

            migrationBuilder.DropTable(
                name: "Sequences");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "ErrandStatuses");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
