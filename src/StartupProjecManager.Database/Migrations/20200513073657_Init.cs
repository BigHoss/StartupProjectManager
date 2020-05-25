using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StartupProjectManager.Database.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectItemTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    Icon = table.Column<byte[]>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectItemTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    ItemTypeId = table.Column<int>(nullable: false),
                    ParentProjectItemId = table.Column<int>(nullable: true),
                    NewProperty = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectItems_ProjectItemTypes_ItemTypeId",
                        column: x => x.ItemTypeId,
                        principalTable: "ProjectItemTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectItems_ProjectItems_ParentProjectItemId",
                        column: x => x.ParentProjectItemId,
                        principalTable: "ProjectItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ProjectItemTypes",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Icon", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[] { 2, "Rku", new DateTime(2020, 5, 13, 7, 36, 57, 389, DateTimeKind.Utc).AddTicks(5053), null, "Rku", new DateTime(2020, 5, 13, 7, 36, 57, 389, DateTimeKind.Utc).AddTicks(5053), "Application" });

            migrationBuilder.InsertData(
                table: "ProjectItemTypes",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Icon", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[] { 3, "Rku", new DateTime(2020, 5, 13, 7, 36, 57, 389, DateTimeKind.Utc).AddTicks(5053), null, "Rku", new DateTime(2020, 5, 13, 7, 36, 57, 389, DateTimeKind.Utc).AddTicks(5053), "Document" });

            migrationBuilder.InsertData(
                table: "ProjectItemTypes",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Icon", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[] { 4, "Rku", new DateTime(2020, 5, 13, 7, 36, 57, 389, DateTimeKind.Utc).AddTicks(5053), null, "Rku", new DateTime(2020, 5, 13, 7, 36, 57, 389, DateTimeKind.Utc).AddTicks(5053), "New" });

            migrationBuilder.InsertData(
                table: "ProjectItemTypes",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Icon", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[] { 5, "Rku", new DateTime(2020, 5, 13, 7, 36, 57, 389, DateTimeKind.Utc).AddTicks(5053), null, "Rku", new DateTime(2020, 5, 13, 7, 36, 57, 389, DateTimeKind.Utc).AddTicks(5053), "Project" });

            migrationBuilder.InsertData(
                table: "ProjectItemTypes",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Icon", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[] { 1, "Rku", new DateTime(2020, 5, 13, 7, 36, 57, 389, DateTimeKind.Utc).AddTicks(5053), null, "Rku", new DateTime(2020, 5, 13, 7, 36, 57, 389, DateTimeKind.Utc).AddTicks(5053), "Root" });

            migrationBuilder.InsertData(
                table: "ProjectItems",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "ItemTypeId", "ModifiedBy", "ModifiedOn", "Name", "NewProperty", "ParentProjectItemId" },
                values: new object[] { 1, "Rku", new DateTime(2020, 5, 13, 7, 36, 57, 389, DateTimeKind.Utc).AddTicks(5053), 1, "Rku", new DateTime(2020, 5, 13, 7, 36, 57, 389, DateTimeKind.Utc).AddTicks(5053), "Root", null, null });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectItems_ItemTypeId",
                table: "ProjectItems",
                column: "ItemTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectItems_ParentProjectItemId",
                table: "ProjectItems",
                column: "ParentProjectItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectItems");

            migrationBuilder.DropTable(
                name: "ProjectItemTypes");
        }
    }
}
