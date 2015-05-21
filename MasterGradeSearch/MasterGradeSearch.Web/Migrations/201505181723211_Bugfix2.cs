namespace MasterGradeSearch.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Bugfix2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Districts", "City_Id", "dbo.Cities");
            DropIndex("dbo.Districts", new[] { "City_Id" });
            RenameColumn(table: "dbo.Districts", name: "City_Id", newName: "CityId");
            AlterColumn("dbo.Districts", "CityId", c => c.Int(nullable: false));
            CreateIndex("dbo.Districts", "CityId");
            AddForeignKey("dbo.Districts", "CityId", "dbo.Cities", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Districts", "CityId", "dbo.Cities");
            DropIndex("dbo.Districts", new[] { "CityId" });
            AlterColumn("dbo.Districts", "CityId", c => c.Int());
            RenameColumn(table: "dbo.Districts", name: "CityId", newName: "City_Id");
            CreateIndex("dbo.Districts", "City_Id");
            AddForeignKey("dbo.Districts", "City_Id", "dbo.Cities", "Id");
        }
    }
}
