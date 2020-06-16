using Microsoft.EntityFrameworkCore.Migrations;

namespace LyrnicsDotnetCore.Migrations
{
    public partial class ChangeBandToArtist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_song_band_band_id",
                table: "song");

            migrationBuilder.DropPrimaryKey(
                name: "pk_band",
                table: "band");

            migrationBuilder.RenameTable(
                name: "band",
                newName: "artist");

            migrationBuilder.AddPrimaryKey(
                name: "pk_artist",
                table: "artist",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_artist_song_artist_id",
                table: "song",
                column: "band_id",
                principalTable: "artist",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_artist_song_artist_id",
                table: "song");

            migrationBuilder.DropPrimaryKey(
                name: "pk_artist",
                table: "artist");

            migrationBuilder.RenameTable(
                name: "artist",
                newName: "band");

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
    }
}
