using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCoreCodeFirstSample.Migrations
{
    /// <inheritdoc />
    public partial class CustomerMetaData2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomersMetaData",
                table: "CustomersMetaData");

            migrationBuilder.DeleteData(
                table: "CustomersMetaData",
                keyColumn: "CustomerId",
                keyColumnType: "text",
                keyValue: "103");

            migrationBuilder.DeleteData(
                table: "CustomersMetaData",
                keyColumn: "CustomerId",
                keyColumnType: "text",
                keyValue: "104");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "CustomersMetaData");

            migrationBuilder.AddColumn<long>(
                name: "CustId",
                table: "CustomersMetaData",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomersMetaData",
                table: "CustomersMetaData",
                column: "CustId");

            migrationBuilder.InsertData(
                table: "CustomersMetaData",
                columns: new[] { "CustId", "OrganizationFriendlyId", "OrganizationId" },
                values: new object[,]
                {
                    { 103L, "123xyz", "xyz123" },
                    { 104L, "123321xyz", "xyz123321" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomersMetaData",
                table: "CustomersMetaData");

            migrationBuilder.DeleteData(
                table: "CustomersMetaData",
                keyColumn: "CustId",
                keyColumnType: "bigint",
                keyValue: 103L);

            migrationBuilder.DeleteData(
                table: "CustomersMetaData",
                keyColumn: "CustId",
                keyColumnType: "bigint",
                keyValue: 104L);

            migrationBuilder.DropColumn(
                name: "CustId",
                table: "CustomersMetaData");

            migrationBuilder.AddColumn<string>(
                name: "CustomerId",
                table: "CustomersMetaData",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomersMetaData",
                table: "CustomersMetaData",
                column: "CustomerId");

            migrationBuilder.InsertData(
                table: "CustomersMetaData",
                columns: new[] { "CustomerId", "OrganizationFriendlyId", "OrganizationId" },
                values: new object[,]
                {
                    { "103", "123xyz", "xyz123" },
                    { "104", "123321xyz", "xyz123321" }
                });
        }
    }
}
