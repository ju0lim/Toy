using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JUYEONG_WEB_APPLICATION.Migrations
{
    /// <inheritdoc />
    public partial class AlterUserInfoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "UserInfo");

            migrationBuilder.AlterColumn<string>(
                name: "TimeStamp",
                table: "UserInfo",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserInfo",
                table: "UserInfo",
                column: "UserNum");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserInfo",
                table: "UserInfo");

            migrationBuilder.RenameTable(
                name: "UserInfo",
                newName: "Users");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeStamp",
                table: "Users",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserNum");
        }
    }
}
