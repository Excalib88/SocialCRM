using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialCRM.DAL.Migrations.Migrations
{
    public partial class addforeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leads_Persons_PersonId",
                table: "Leads");

            migrationBuilder.DropForeignKey(
                name: "FK_Legals_Companies_CompanyId",
                table: "Legals");

            migrationBuilder.DropForeignKey(
                name: "FK_Legals_Leads_LeadId",
                table: "Legals");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Leads_LeadId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Orders_OrderEntityId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_OrderEntityId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OrderEntityId",
                table: "Products");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Products",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ProductsId",
                table: "Products",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "LeadId",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<List<Guid>>(
                name: "ProductsId",
                table: "Orders",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "LeadId",
                table: "Legals",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CompanyId",
                table: "Legals",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "PersonId",
                table: "Leads",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "CategoryEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    UserCreated = table.Column<Guid>(nullable: true),
                    UserUpdated = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryEntity", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductsId",
                table: "Products",
                column: "ProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Leads_Persons_PersonId",
                table: "Leads",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Legals_Companies_CompanyId",
                table: "Legals",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Legals_Leads_LeadId",
                table: "Legals",
                column: "LeadId",
                principalTable: "Leads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Leads_LeadId",
                table: "Orders",
                column: "LeadId",
                principalTable: "Leads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_CategoryEntity_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "CategoryEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Orders_ProductsId",
                table: "Products",
                column: "ProductsId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leads_Persons_PersonId",
                table: "Leads");

            migrationBuilder.DropForeignKey(
                name: "FK_Legals_Companies_CompanyId",
                table: "Legals");

            migrationBuilder.DropForeignKey(
                name: "FK_Legals_Leads_LeadId",
                table: "Legals");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Leads_LeadId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_CategoryEntity_CategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Orders_ProductsId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "CategoryEntity");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductsId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductsId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductsId",
                table: "Orders");

            migrationBuilder.AddColumn<Guid>(
                name: "OrderEntityId",
                table: "Products",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "LeadId",
                table: "Orders",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "LeadId",
                table: "Legals",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "CompanyId",
                table: "Legals",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "PersonId",
                table: "Leads",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.CreateIndex(
                name: "IX_Products_OrderEntityId",
                table: "Products",
                column: "OrderEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Leads_Persons_PersonId",
                table: "Leads",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Legals_Companies_CompanyId",
                table: "Legals",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Legals_Leads_LeadId",
                table: "Legals",
                column: "LeadId",
                principalTable: "Leads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Leads_LeadId",
                table: "Orders",
                column: "LeadId",
                principalTable: "Leads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Orders_OrderEntityId",
                table: "Products",
                column: "OrderEntityId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
