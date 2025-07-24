using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WalksAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataForDifficultiesandRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("158c5470-7990-40c0-a0c2-0884cfd0378f"), "Easy" },
                    { new Guid("a2a31082-c3c7-4e96-96a4-43d662e06d6f"), "Medium" },
                    { new Guid("b6f10401-c0da-4674-a5cd-20a8680ea0a3"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("b0d2f1c3-4e8a-4c5b-9f6d-7e8f9a0b1c2d"), "WR", "West Region", "https://example.com/west-region.jpg" },
                    { new Guid("c3b0d2f1-4e8a-4c5b-9f6d-7e8f9a0b1c2d"), "ER", "East Region", "https://example.com/east-region.jpg" },
                    { new Guid("d2c3b0d2-4e8a-4c5b-9f6d-7e8f9a0b1c2d"), "SR", "South Region", "https://example.com/south-region.jpg" },
                    { new Guid("f1c3b0d2-4e8a-4c5b-9f6d-7e8f9a0b1c2d"), "NR", "North Region", "https://example.com/north-region.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "difficulties",
                keyColumn: "Id",
                keyValue: new Guid("158c5470-7990-40c0-a0c2-0884cfd0378f"));

            migrationBuilder.DeleteData(
                table: "difficulties",
                keyColumn: "Id",
                keyValue: new Guid("a2a31082-c3c7-4e96-96a4-43d662e06d6f"));

            migrationBuilder.DeleteData(
                table: "difficulties",
                keyColumn: "Id",
                keyValue: new Guid("b6f10401-c0da-4674-a5cd-20a8680ea0a3"));

            migrationBuilder.DeleteData(
                table: "regions",
                keyColumn: "Id",
                keyValue: new Guid("b0d2f1c3-4e8a-4c5b-9f6d-7e8f9a0b1c2d"));

            migrationBuilder.DeleteData(
                table: "regions",
                keyColumn: "Id",
                keyValue: new Guid("c3b0d2f1-4e8a-4c5b-9f6d-7e8f9a0b1c2d"));

            migrationBuilder.DeleteData(
                table: "regions",
                keyColumn: "Id",
                keyValue: new Guid("d2c3b0d2-4e8a-4c5b-9f6d-7e8f9a0b1c2d"));

            migrationBuilder.DeleteData(
                table: "regions",
                keyColumn: "Id",
                keyValue: new Guid("f1c3b0d2-4e8a-4c5b-9f6d-7e8f9a0b1c2d"));
        }
    }
}
