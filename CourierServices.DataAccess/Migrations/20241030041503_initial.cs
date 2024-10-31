using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourierServices.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FinalOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Weight_WeightValue = table.Column<double>(type: "float", nullable: false),
                    District_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    District_NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    District_DistrictId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryTime_DeliveryTimeValue = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinalOrders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Query = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Weight_WeightValue = table.Column<double>(type: "float", nullable: false),
                    District_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    District_NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    District_DistrictId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryTime_DeliveryTimeValue = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FinalOrders");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
