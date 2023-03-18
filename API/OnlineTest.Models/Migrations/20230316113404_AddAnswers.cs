using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineTest.Models.Migrations
{
    /// <inheritdoc />
    public partial class AddAnswers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Technologies_Users_CreatedBy",
                table: "Technologies");

            migrationBuilder.DropForeignKey(
                name: "FK_Technologies_Users_ModifiedBy",
                table: "Technologies");

            migrationBuilder.DropForeignKey(
                name: "FK_Tests_Users_CreatedBy",
                table: "Tests");

            migrationBuilder.DropIndex(
                name: "IX_Tests_CreatedBy",
                table: "Tests");

            migrationBuilder.DropIndex(
                name: "IX_Technologies_CreatedBy",
                table: "Technologies");

            migrationBuilder.DropIndex(
                name: "IX_Technologies_ModifiedBy",
                table: "Technologies");

            migrationBuilder.RenameColumn(
                name: "CreatedTime",
                table: "Tests",
                newName: "CreatedOn");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "RTokens",
                newName: "CreatedOn");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireOn",
                table: "Tests",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Tests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Technologies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Questions",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Questions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ans = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Technologies");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "Tests",
                newName: "CreatedTime");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "RTokens",
                newName: "CreatedDate");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpireOn",
                table: "Tests",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tests_CreatedBy",
                table: "Tests",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Technologies_CreatedBy",
                table: "Technologies",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Technologies_ModifiedBy",
                table: "Technologies",
                column: "ModifiedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Technologies_Users_CreatedBy",
                table: "Technologies",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Technologies_Users_ModifiedBy",
                table: "Technologies",
                column: "ModifiedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_Users_CreatedBy",
                table: "Tests",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
