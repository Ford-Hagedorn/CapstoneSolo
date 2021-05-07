using Microsoft.EntityFrameworkCore.Migrations;

namespace HowdyFresh.Migrations
{
    public partial class forediting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5648fe1a-ee4f-424e-b11a-592a3d53107c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ab11c4b-f0a4-4474-8a7f-c4e3cd3e1993");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2f195897-1820-4c61-b25f-ca144bc9cff3", "f816db9e-56c3-4a7e-a85a-3de455a4ef90", "Restaurant", "RESTAURANT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1f534c2a-05c7-4d32-b78e-fc0da28bdfeb", "b9f27e19-b26c-4eb7-98d4-e53c3a1b2b9f", "Supplier", "SUPPLIER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f534c2a-05c7-4d32-b78e-fc0da28bdfeb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2f195897-1820-4c61-b25f-ca144bc9cff3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6ab11c4b-f0a4-4474-8a7f-c4e3cd3e1993", "1424bcac-1ab0-49eb-be82-d3623fe201e3", "Restaurant", "RESTAURANT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5648fe1a-ee4f-424e-b11a-592a3d53107c", "8188e121-b141-426a-8f6e-0ecc3a0a0268", "Supplier", "SUPPLIER" });
        }
    }
}
