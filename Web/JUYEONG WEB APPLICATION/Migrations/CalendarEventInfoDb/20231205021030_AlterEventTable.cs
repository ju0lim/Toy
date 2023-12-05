using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JUYEONG_WEB_APPLICATION.Migrations.CalendarEventInfoDb
{
    /// <inheritdoc />
    public partial class AlterEventTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CalendarEventInfo",
                table: "CalendarEventInfo");

            migrationBuilder.AlterColumn<string>(
                name: "End",
                table: "CalendarEventInfo",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Start",
                table: "CalendarEventInfo",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "CalendarEventInfo",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "EventID",
                table: "CalendarEventInfo",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CalendarEventInfo",
                table: "CalendarEventInfo",
                column: "EventID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CalendarEventInfo",
                table: "CalendarEventInfo");

            migrationBuilder.DropColumn(
                name: "EventID",
                table: "CalendarEventInfo");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "CalendarEventInfo",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Start",
                table: "CalendarEventInfo",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "End",
                table: "CalendarEventInfo",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CalendarEventInfo",
                table: "CalendarEventInfo",
                columns: new[] { "Title", "Start", "End" });
        }
    }
}
