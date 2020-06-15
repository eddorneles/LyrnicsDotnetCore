using Microsoft.EntityFrameworkCore.Migrations;

namespace LyrnicsDotnetCore.Migrations
{
    public partial class DatabaseNamesChangesToPGConvention : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Bands_BandId",
                table: "Songs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Songs",
                table: "Songs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bands",
                table: "Bands");

            migrationBuilder.RenameTable(
                name: "Songs",
                newName: "song");

            migrationBuilder.RenameTable(
                name: "Bands",
                newName: "band");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "song",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "song",
                newName: "code");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "song",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "BandId",
                table: "song",
                newName: "band_id");

            migrationBuilder.RenameIndex(
                name: "IX_Songs_BandId",
                table: "song",
                newName: "IX_song_band_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "band",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "band",
                newName: "code");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "band",
                newName: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_song",
                table: "song",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_band",
                table: "band",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_song_band_band_id",
                table: "song",
                column: "band_id",
                principalTable: "band",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_song_band_band_id",
                table: "song");

            migrationBuilder.DropPrimaryKey(
                name: "pk_song",
                table: "song");

            migrationBuilder.DropPrimaryKey(
                name: "pk_band",
                table: "band");

            migrationBuilder.RenameTable(
                name: "song",
                newName: "Songs");

            migrationBuilder.RenameTable(
                name: "band",
                newName: "Bands");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Songs",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "code",
                table: "Songs",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Songs",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "band_id",
                table: "Songs",
                newName: "BandId");

            migrationBuilder.RenameIndex(
                name: "IX_song_band_id",
                table: "Songs",
                newName: "IX_Songs_BandId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Bands",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "code",
                table: "Bands",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Bands",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Songs",
                table: "Songs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bands",
                table: "Bands",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Bands_BandId",
                table: "Songs",
                column: "BandId",
                principalTable: "Bands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
