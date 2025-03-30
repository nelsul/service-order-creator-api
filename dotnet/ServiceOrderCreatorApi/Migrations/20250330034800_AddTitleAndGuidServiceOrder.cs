using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ServiceOrderCreatorApi.Migrations
{
    /// <inheritdoc />
    public partial class AddTitleAndGuidServiceOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e7334f4-63ea-4a4d-86cf-d92a897b5571"
            );

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a21d57b-4f39-4b64-9ed7-db2301f6c8c8"
            );

            migrationBuilder.AlterColumn<Guid>(
                name: "Guid",
                table: "ServiceOrders",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)"
            );

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "ServiceOrders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: ""
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(name: "Title", table: "ServiceOrders");

            migrationBuilder.AlterColumn<string>(
                name: "Guid",
                table: "ServiceOrders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier"
            );

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4e7334f4-63ea-4a4d-86cf-d92a897b5571", null, "Admin", "ADMIN" },
                    { "6a21d57b-4f39-4b64-9ed7-db2301f6c8c8", null, "User", "USER" },
                }
            );
        }
    }
}
