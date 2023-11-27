using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JUYEONG_WEB_APPLICATION.Migrations
{
    /// <inheritdoc />
    public partial class CreateUserInfoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserInfo",
                table: "UserInfo");

            migrationBuilder.DropColumn(
                name: "UserNum",
                table: "UserInfo");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "UserInfo",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserInfo",
                table: "UserInfo",
                column: "Email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserInfo",
                table: "UserInfo");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "UserInfo",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "UserNum",
                table: "UserInfo",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserInfo",
                table: "UserInfo",
                column: "UserNum");
        }
    }
}
