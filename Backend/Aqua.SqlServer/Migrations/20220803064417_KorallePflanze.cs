using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace com.marcelbenders.Aqua.SqlServer.Migrations
{
    public partial class KorallePflanze : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Korallen_AppUsers_UserId",
                table: "Korallen");

            migrationBuilder.DropForeignKey(
                name: "FK_Korallen_Aquarien_AquariumId",
                table: "Korallen");

            migrationBuilder.DropForeignKey(
                name: "FK_Pflanzen_AppUsers_UserId",
                table: "Pflanzen");

            migrationBuilder.DropForeignKey(
                name: "FK_Pflanzen_Aquarien_AquariumId",
                table: "Pflanzen");

            migrationBuilder.DropIndex(
                name: "IX_Pflanzen_AquariumId",
                table: "Pflanzen");

            migrationBuilder.DropIndex(
                name: "IX_Pflanzen_UserId",
                table: "Pflanzen");

            migrationBuilder.DropIndex(
                name: "IX_Korallen_AquariumId",
                table: "Korallen");

            migrationBuilder.DropIndex(
                name: "IX_Korallen_UserId",
                table: "Korallen");

            migrationBuilder.DropColumn(
                name: "AquariumId",
                table: "Pflanzen");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Pflanzen");

            migrationBuilder.DropColumn(
                name: "AquariumId",
                table: "Korallen");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Korallen");

            migrationBuilder.AddColumn<string>(
                name: "AppUserUserId",
                table: "Pflanzen",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserUserId",
                table: "Korallen",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pflanzen_AppUserUserId",
                table: "Pflanzen",
                column: "AppUserUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Korallen_AppUserUserId",
                table: "Korallen",
                column: "AppUserUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Korallen_AppUsers_AppUserUserId",
                table: "Korallen",
                column: "AppUserUserId",
                principalTable: "AppUsers",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pflanzen_AppUsers_AppUserUserId",
                table: "Pflanzen",
                column: "AppUserUserId",
                principalTable: "AppUsers",
                principalColumn: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Korallen_AppUsers_AppUserUserId",
                table: "Korallen");

            migrationBuilder.DropForeignKey(
                name: "FK_Pflanzen_AppUsers_AppUserUserId",
                table: "Pflanzen");

            migrationBuilder.DropIndex(
                name: "IX_Pflanzen_AppUserUserId",
                table: "Pflanzen");

            migrationBuilder.DropIndex(
                name: "IX_Korallen_AppUserUserId",
                table: "Korallen");

            migrationBuilder.DropColumn(
                name: "AppUserUserId",
                table: "Pflanzen");

            migrationBuilder.DropColumn(
                name: "AppUserUserId",
                table: "Korallen");

            migrationBuilder.AddColumn<Guid>(
                name: "AquariumId",
                table: "Pflanzen",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Pflanzen",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "AquariumId",
                table: "Korallen",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Korallen",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Pflanzen_AquariumId",
                table: "Pflanzen",
                column: "AquariumId");

            migrationBuilder.CreateIndex(
                name: "IX_Pflanzen_UserId",
                table: "Pflanzen",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Korallen_AquariumId",
                table: "Korallen",
                column: "AquariumId");

            migrationBuilder.CreateIndex(
                name: "IX_Korallen_UserId",
                table: "Korallen",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Korallen_AppUsers_UserId",
                table: "Korallen",
                column: "UserId",
                principalTable: "AppUsers",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Korallen_Aquarien_AquariumId",
                table: "Korallen",
                column: "AquariumId",
                principalTable: "Aquarien",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pflanzen_AppUsers_UserId",
                table: "Pflanzen",
                column: "UserId",
                principalTable: "AppUsers",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pflanzen_Aquarien_AquariumId",
                table: "Pflanzen",
                column: "AquariumId",
                principalTable: "Aquarien",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
