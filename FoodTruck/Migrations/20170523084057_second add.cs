using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodTruck.Migrations
{
    public partial class secondadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Foodtrucks",
                table: "Foodtrucks");

            migrationBuilder.RenameTable(
                name: "Foodtrucks",
                newName: "Trucks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trucks",
                table: "Trucks",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Trucks",
                table: "Trucks");

            migrationBuilder.RenameTable(
                name: "Trucks",
                newName: "Foodtrucks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Foodtrucks",
                table: "Foodtrucks",
                column: "Id");
        }
    }
}
