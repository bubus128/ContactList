using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactList.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSubCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SubcategoryId",
                table: "Contacts",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_SubcategoryId",
                table: "Contacts",
                column: "SubcategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Category_SubcategoryId",
                table: "Contacts",
                column: "SubcategoryId",
                principalTable: "Category",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Category_SubcategoryId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_SubcategoryId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "SubcategoryId",
                table: "Contacts");
        }
    }
}
