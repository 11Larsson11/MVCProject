using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCProject.Migrations
{
    public partial class updatedbirthdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7f06b31-7425-495d-99a7-8fe1efd52afa");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "1abda728-073e-4280-a97f-adb8c43195fb", "f9b474f8-392d-4f46-923c-3569b3751653" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9b474f8-392d-4f46-923c-3569b3751653");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1abda728-073e-4280-a97f-adb8c43195fb");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "BirthDate",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b9a78e6b-cbcb-4043-8fa3-6438349f640e", "80421f6b-2ffa-4677-aab9-89de32467b26", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "957be7b0-172b-4e19-9c4a-434afaa9a07e", "cbce1087-34d8-4380-8908-3cf93980c429", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c53ad8b4-7e7e-4cb6-9f18-b6bf0ee9cb59", 0, "2001-02-18", "c3668fa0-afcd-4541-903b-e5f773615958", "admin@admin.com", false, "Bruno", "Spekel", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEPxZ8ZJU2nZuspNImG3oZDlCcZL82jMjg6z+tRZJSePYRPsr/UqX+qRZN/hcMQD2qg==", null, false, "18239716-8dd3-4f8e-b760-bd3e20729dc9", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "c53ad8b4-7e7e-4cb6-9f18-b6bf0ee9cb59", "b9a78e6b-cbcb-4043-8fa3-6438349f640e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "957be7b0-172b-4e19-9c4a-434afaa9a07e");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "c53ad8b4-7e7e-4cb6-9f18-b6bf0ee9cb59", "b9a78e6b-cbcb-4043-8fa3-6438349f640e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b9a78e6b-cbcb-4043-8fa3-6438349f640e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c53ad8b4-7e7e-4cb6-9f18-b6bf0ee9cb59");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f9b474f8-392d-4f46-923c-3569b3751653", "baabf27d-3fb1-4d8f-9180-f2d118c9614a", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a7f06b31-7425-495d-99a7-8fe1efd52afa", "2b79a832-0dee-474a-95cf-2f753340b0ae", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Age", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1abda728-073e-4280-a97f-adb8c43195fb", 0, 9, "bfd428ce-cea6-453d-8c26-d2c2f17d5af2", "admin@admin.com", false, "Bruno", "Spekel", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEMlKZ+jIERMj5bvy05fy5T2PLt0hNl1b8cgzoJs7x6RdE8ekCNO0mIXDXuKFY33KRw==", null, false, "2d0da751-0aa1-4730-bf7e-3c00f26032a2", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "1abda728-073e-4280-a97f-adb8c43195fb", "f9b474f8-392d-4f46-923c-3569b3751653" });
        }
    }
}
