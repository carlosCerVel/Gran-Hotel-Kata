using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GranHotelKata.Migrations
{
    public partial class AddCheckOutEventTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CheckOutEvent",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    CheckOutDate = table.Column<DateTime>(nullable: false),
                    CheckOutDateDiscrepancyDetected = table.Column<bool>(nullable: false),
                    Comments = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckOutEvent", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Guess_CheckOutEventId",
                table: "Guess",
                column: "CheckOutEventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Guess_CheckOutEvent_CheckOutEventId",
                table: "Guess",
                column: "CheckOutEventId",
                principalTable: "CheckOutEvent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guess_CheckOutEvent_CheckOutEventId",
                table: "Guess");

            migrationBuilder.DropTable(
                name: "CheckOutEvent");

            migrationBuilder.DropIndex(
                name: "IX_Guess_CheckOutEventId",
                table: "Guess");
        }
    }
}
