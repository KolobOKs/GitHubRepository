namespace MasterGradeSearch.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Bugfix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Districts", "City_Id", "dbo.Cities");
            DropIndex("dbo.Districts", new[] { "City_Id" });
            AlterColumn("dbo.Districts", "City_Id", c => c.Int());
            CreateIndex("dbo.Districts", "City_Id");
            AddForeignKey("dbo.Districts", "City_Id", "dbo.Cities", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Districts", "City_Id", "dbo.Cities");
            DropIndex("dbo.Districts", new[] { "City_Id" });
            AlterColumn("dbo.Districts", "City_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Districts", "City_Id");
            AddForeignKey("dbo.Districts", "City_Id", "dbo.Cities", "Id", cascadeDelete: true);
        }
    }
}
