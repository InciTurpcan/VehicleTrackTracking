using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vechicle_Track_WebApi.Migrations
{
    public partial class def_Procedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Car için Add Procedure
            migrationBuilder.Sql(@"
        CREATE PROCEDURE AddCar
            @PlateNumber NVARCHAR(50),
            @Brand NVARCHAR(100),
            @Model NVARCHAR(100),
            @Color NVARCHAR(50)
        AS
        BEGIN
            INSERT INTO Cars (PlateNumber, Brand, Model, Color)
            VALUES (@PlateNumber, @Brand, @Model, @Color)
        END
    ");

            // Part için Add Procedure
            migrationBuilder.Sql(@"
        CREATE PROCEDURE AddPart
            @Name NVARCHAR(100),            
            @PartCategoryId INT
        AS
        BEGIN
            INSERT INTO Parts (Name, PartCategoryId)
            VALUES (@Name, @PartCategoryId)
        END
    ");

            // PartCategory için Add Procedure
            migrationBuilder.Sql(@"
        CREATE PROCEDURE AddPartCategory
            @PartCategoryName NVARCHAR(100)
        AS
        BEGIN
            INSERT INTO PartCategories (PartCategoryName)
            VALUES (@PartCategoryName)
        END
    ");

        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
