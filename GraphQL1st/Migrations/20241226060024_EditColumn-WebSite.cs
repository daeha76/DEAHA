using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAEHA.GraphQL1st.Migrations
{
    /// <inheritdoc />
    public partial class EditColumnWebSite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Website",
                table: "Speakers",
                newName: "WebSite");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WebSite",
                table: "Speakers",
                newName: "Website");
        }
    }
}
