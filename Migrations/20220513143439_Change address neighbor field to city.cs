using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviesAPI.Migrations
{
    public partial class Changeaddressneighborfieldtocity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER TABLE Addresses 
                            RENAME COLUMN Neighbor TO City;");
        }

        
    }
}
