using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace com.marcelbenders.Aqua.SqlServer.Migrations
{
    public partial class AddCommonUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Pflanzen",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Notizen",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Messungen",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Korallen",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Fische",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Duengungen",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Aquarien",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.UserId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pflanzen_UserId",
                table: "Pflanzen",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Notizen_UserId",
                table: "Notizen",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messungen_UserId",
                table: "Messungen",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Korallen_UserId",
                table: "Korallen",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Fische_UserId",
                table: "Fische",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Duengungen_UserId",
                table: "Duengungen",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Aquarien_UserId",
                table: "Aquarien",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Aquarien_AppUsers_UserId",
                table: "Aquarien",
                column: "UserId",
                principalTable: "AppUsers",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Duengungen_AppUsers_UserId",
                table: "Duengungen",
                column: "UserId",
                principalTable: "AppUsers",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fische_AppUsers_UserId",
                table: "Fische",
                column: "UserId",
                principalTable: "AppUsers",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Korallen_AppUsers_UserId",
                table: "Korallen",
                column: "UserId",
                principalTable: "AppUsers",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messungen_AppUsers_UserId",
                table: "Messungen",
                column: "UserId",
                principalTable: "AppUsers",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notizen_AppUsers_UserId",
                table: "Notizen",
                column: "UserId",
                principalTable: "AppUsers",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pflanzen_AppUsers_UserId",
                table: "Pflanzen",
                column: "UserId",
                principalTable: "AppUsers",
                principalColumn: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aquarien_AppUsers_UserId",
                table: "Aquarien");

            migrationBuilder.DropForeignKey(
                name: "FK_Duengungen_AppUsers_UserId",
                table: "Duengungen");

            migrationBuilder.DropForeignKey(
                name: "FK_Fische_AppUsers_UserId",
                table: "Fische");

            migrationBuilder.DropForeignKey(
                name: "FK_Korallen_AppUsers_UserId",
                table: "Korallen");

            migrationBuilder.DropForeignKey(
                name: "FK_Messungen_AppUsers_UserId",
                table: "Messungen");

            migrationBuilder.DropForeignKey(
                name: "FK_Notizen_AppUsers_UserId",
                table: "Notizen");

            migrationBuilder.DropForeignKey(
                name: "FK_Pflanzen_AppUsers_UserId",
                table: "Pflanzen");

            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.DropIndex(
                name: "IX_Pflanzen_UserId",
                table: "Pflanzen");

            migrationBuilder.DropIndex(
                name: "IX_Notizen_UserId",
                table: "Notizen");

            migrationBuilder.DropIndex(
                name: "IX_Messungen_UserId",
                table: "Messungen");

            migrationBuilder.DropIndex(
                name: "IX_Korallen_UserId",
                table: "Korallen");

            migrationBuilder.DropIndex(
                name: "IX_Fische_UserId",
                table: "Fische");

            migrationBuilder.DropIndex(
                name: "IX_Duengungen_UserId",
                table: "Duengungen");

            migrationBuilder.DropIndex(
                name: "IX_Aquarien_UserId",
                table: "Aquarien");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Pflanzen",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Notizen",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Messungen",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Korallen",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Fische",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Duengungen",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Aquarien",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
