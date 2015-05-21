namespace MasterGradeSearch.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Bugfix4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "Institute_Id", "dbo.Institutes");
            DropIndex("dbo.Courses", new[] { "Institute_Id" });
            RenameColumn(table: "dbo.Courses", name: "Institute_Id", newName: "InstituteId");
            AlterColumn("dbo.Courses", "InstituteId", c => c.Int(nullable: false));
            CreateIndex("dbo.Courses", "InstituteId");
            AddForeignKey("dbo.Courses", "InstituteId", "dbo.Institutes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "InstituteId", "dbo.Institutes");
            DropIndex("dbo.Courses", new[] { "InstituteId" });
            AlterColumn("dbo.Courses", "InstituteId", c => c.Int());
            RenameColumn(table: "dbo.Courses", name: "InstituteId", newName: "Institute_Id");
            CreateIndex("dbo.Courses", "Institute_Id");
            AddForeignKey("dbo.Courses", "Institute_Id", "dbo.Institutes", "Id");
        }
    }
}
