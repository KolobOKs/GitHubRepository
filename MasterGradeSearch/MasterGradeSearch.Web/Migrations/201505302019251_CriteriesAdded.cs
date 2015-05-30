namespace MasterGradeSearch.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriteriesAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CriterionRatios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CriterionSourceId = c.Int(nullable: false),
                        CriterionDestinationId = c.Int(nullable: false),
                        Ratio = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Criteria", t => t.CriterionDestinationId)
                .ForeignKey("dbo.Criteria", t => t.CriterionSourceId, cascadeDelete: true)
                .Index(t => t.CriterionSourceId)
                .Index(t => t.CriterionDestinationId);
            
            CreateTable(
                "dbo.Criteria",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CriterionRatios", "CriterionSourceId", "dbo.Criteria");
            DropForeignKey("dbo.CriterionRatios", "CriterionDestinationId", "dbo.Criteria");
            DropIndex("dbo.CriterionRatios", new[] { "CriterionDestinationId" });
            DropIndex("dbo.CriterionRatios", new[] { "CriterionSourceId" });
            DropTable("dbo.Criteria");
            DropTable("dbo.CriterionRatios");
        }
    }
}
