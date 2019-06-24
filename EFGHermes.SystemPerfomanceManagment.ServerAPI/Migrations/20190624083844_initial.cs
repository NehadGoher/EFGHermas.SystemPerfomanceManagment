using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFGHermes.SystemPerfomanceManagment.ServerAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IP = table.Column<string>(nullable: true),
                    Port = table.Column<int>(nullable: false),
                    DisplayName = table.Column<string>(nullable: true),
                    DBConnectionString = table.Column<string>(nullable: true),
                    ServiceStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceRelationship",
                columns: table => new
                {
                    FromServiceId = table.Column<int>(nullable: false),
                    ToServiceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceRelationship", x => new { x.FromServiceId, x.ToServiceId });
                    table.ForeignKey(
                        name: "FK_ServiceRelationship_Services_FromServiceId",
                        column: x => x.FromServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceRelationship_Services_ToServiceId",
                        column: x => x.ToServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRelationship_ToServiceId",
                table: "ServiceRelationship",
                column: "ToServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceRelationship");

            migrationBuilder.DropTable(
                name: "Services");
        }
    }
}
