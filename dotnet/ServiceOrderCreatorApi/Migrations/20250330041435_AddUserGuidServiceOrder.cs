using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ServiceOrderCreatorApi.Migrations
{
    /// <inheritdoc />
    public partial class AddUserGuidServiceOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOrders_AspNetUsers_UserId",
                table: "ServiceOrders"
            );

            migrationBuilder.DropIndex(name: "IX_ServiceOrders_UserId", table: "ServiceOrders");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "805777ee-eca6-41da-9cf2-ac961babee57"
            );

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a469ad8a-071b-4f46-82e6-0c978f65bcda"
            );

            migrationBuilder.RenameColumn(
                name: "Guid",
                table: "ServiceOrders",
                newName: "PublicId"
            );

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "ServiceOrders",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true
            );

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "ServiceOrders",
                type: "nvarchar(450)",
                nullable: true
            );

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0c1aaac7-5518-4fd2-9416-684a7ff173fb", null, "Admin", "ADMIN" },
                    { "1c38d7d0-0fb6-4d71-b549-aab7a6235121", null, "User", "USER" },
                }
            );

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrders_UserId1",
                table: "ServiceOrders",
                column: "UserId1"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOrders_AspNetUsers_UserId1",
                table: "ServiceOrders",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOrders_AspNetUsers_UserId1",
                table: "ServiceOrders"
            );

            migrationBuilder.DropIndex(name: "IX_ServiceOrders_UserId1", table: "ServiceOrders");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0c1aaac7-5518-4fd2-9416-684a7ff173fb"
            );

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1c38d7d0-0fb6-4d71-b549-aab7a6235121"
            );

            migrationBuilder.DropColumn(name: "UserId1", table: "ServiceOrders");

            migrationBuilder.RenameColumn(
                name: "PublicId",
                table: "ServiceOrders",
                newName: "Guid"
            );

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ServiceOrders",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true
            );

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "805777ee-eca6-41da-9cf2-ac961babee57", null, "User", "USER" },
                    { "a469ad8a-071b-4f46-82e6-0c978f65bcda", null, "Admin", "ADMIN" },
                }
            );

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrders_UserId",
                table: "ServiceOrders",
                column: "UserId"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOrders_AspNetUsers_UserId",
                table: "ServiceOrders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id"
            );
        }
    }
}
