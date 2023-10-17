using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace InventoryManagement.Infrastructure.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InventoryGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ParentId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryGroups_InventoryGroups_ParentId",
                        column: x => x.ParentId,
                        principalTable: "InventoryGroups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VehicleInventories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Marka = table.Column<string>(type: "text", nullable: false),
                    Model = table.Column<string>(type: "text", nullable: false),
                    ModelYear = table.Column<short>(type: "smallint", nullable: false),
                    SasiNo = table.Column<string>(type: "text", nullable: true),
                    MotorNo = table.Column<string>(type: "text", nullable: true),
                    LicencePlate = table.Column<string>(type: "text", nullable: false),
                    EntryDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Segment = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleInventories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Marka = table.Column<string>(type: "text", nullable: false),
                    Model = table.Column<string>(type: "text", nullable: false),
                    SeriNo = table.Column<string>(type: "text", nullable: false),
                    InventoryGroupId = table.Column<int>(type: "integer", nullable: false),
                    EntryDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    GuaranteeStart = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    GuaranteeEnd = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Price = table.Column<double>(type: "double precision", nullable: true),
                    WhereAbout = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventories_InventoryGroups_InventoryGroupId",
                        column: x => x.InventoryGroupId,
                        principalTable: "InventoryGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_InventoryGroupId",
                table: "Inventories",
                column: "InventoryGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryGroups_ParentId",
                table: "InventoryGroups",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "VehicleInventories");

            migrationBuilder.DropTable(
                name: "InventoryGroups");
        }
    }
}
