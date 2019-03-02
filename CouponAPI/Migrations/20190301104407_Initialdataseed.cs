using Microsoft.EntityFrameworkCore.Migrations;

namespace CouponAPI.Migrations
{
    public partial class Initialdataseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CouponCodes",
                columns: table => new
                {
                    CoupounId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(nullable: true),
                    Totalamount = table.Column<long>(nullable: true),
                    Noofcustomer = table.Column<int>(nullable: true),
                    Paynoofcustomer = table.Column<int>(nullable: true),
                    Discount = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CouponCodes", x => x.CoupounId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CouponCodes");
        }
    }
}
