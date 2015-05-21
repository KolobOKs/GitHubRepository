namespace MasterGradeSearch.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Bugfix3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Institutes", "District_Id", "dbo.Districts");
            DropIndex("dbo.Institutes", new[] { "District_Id" });
            RenameColumn(table: "dbo.Courses", name: "Discipline_Id", newName: "DisciplineId");
            RenameColumn(table: "dbo.Institutes", name: "City_Id", newName: "CityId");
            RenameColumn(table: "dbo.Institutes", name: "District_Id", newName: "DistrictId");
            RenameIndex(table: "dbo.Courses", name: "IX_Discipline_Id", newName: "IX_DisciplineId");
            RenameIndex(table: "dbo.Institutes", name: "IX_City_Id", newName: "IX_CityId");
            AlterColumn("dbo.Institutes", "DistrictId", c => c.Int(nullable: false));
            CreateIndex("dbo.Institutes", "DistrictId");
            AddForeignKey("dbo.Institutes", "DistrictId", "dbo.Districts", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Institutes", "DistrictId", "dbo.Districts");
            DropIndex("dbo.Institutes", new[] { "DistrictId" });
            AlterColumn("dbo.Institutes", "DistrictId", c => c.Int());
            RenameIndex(table: "dbo.Institutes", name: "IX_CityId", newName: "IX_City_Id");
            RenameIndex(table: "dbo.Courses", name: "IX_DisciplineId", newName: "IX_Discipline_Id");
            RenameColumn(table: "dbo.Institutes", name: "DistrictId", newName: "District_Id");
            RenameColumn(table: "dbo.Institutes", name: "CityId", newName: "City_Id");
            RenameColumn(table: "dbo.Courses", name: "DisciplineId", newName: "Discipline_Id");
            CreateIndex("dbo.Institutes", "District_Id");
            AddForeignKey("dbo.Institutes", "District_Id", "dbo.Districts", "Id");
        }
    }
}
