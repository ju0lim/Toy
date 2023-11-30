using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JUYEONG_WEB_APPLICATION.Migrations.CalendarEventInfoDb
{
    /// <inheritdoc />
    public partial class AddCalendarInfoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CalendarEventInfo",
                columns: table => new
                {
                    Title = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Start = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    End = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TimeStamp = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarEventInfo", x => new { x.Title, x.Start, x.End });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalendarEventInfo");
        }
    }
}
