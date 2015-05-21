namespace MasterGradeSearch.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Commonstypesadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LearningType = c.Int(nullable: false),
                        PreparatoryCourses = c.Boolean(nullable: false),
                        Hostel = c.Boolean(nullable: false),
                        Budget = c.Boolean(nullable: false),
                        Extrabudgetary = c.Boolean(nullable: false),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discipline_Id = c.Int(nullable: false),
                        Institute_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Disciplines", t => t.Discipline_Id, cascadeDelete: true)
                .ForeignKey("dbo.Institutes", t => t.Institute_Id)
                .Index(t => t.Discipline_Id)
                .Index(t => t.Institute_Id);
            
            CreateTable(
                "dbo.Disciplines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Discipline_Id = c.Int(),
                        Course_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Disciplines", t => t.Discipline_Id)
                .ForeignKey("dbo.Courses", t => t.Course_Id)
                .Index(t => t.Discipline_Id)
                .Index(t => t.Course_Id);
            
            CreateTable(
                "dbo.Districts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 60),
                        City_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.City_Id, cascadeDelete: true)
                .Index(t => t.City_Id);
            
            CreateTable(
                "dbo.Institutes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ShortName = c.String(nullable: false, maxLength: 20),
                        FullName = c.String(nullable: false, maxLength: 100),
                        City_Id = c.Int(nullable: false),
                        District_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.City_Id, cascadeDelete: true)
                .ForeignKey("dbo.Districts", t => t.District_Id)
                .Index(t => t.City_Id)
                .Index(t => t.District_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Institutes", "District_Id", "dbo.Districts");
            DropForeignKey("dbo.Courses", "Institute_Id", "dbo.Institutes");
            DropForeignKey("dbo.Institutes", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.Districts", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.Exams", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.Courses", "Discipline_Id", "dbo.Disciplines");
            DropForeignKey("dbo.Exams", "Discipline_Id", "dbo.Disciplines");
            DropIndex("dbo.Institutes", new[] { "District_Id" });
            DropIndex("dbo.Institutes", new[] { "City_Id" });
            DropIndex("dbo.Districts", new[] { "City_Id" });
            DropIndex("dbo.Exams", new[] { "Course_Id" });
            DropIndex("dbo.Exams", new[] { "Discipline_Id" });
            DropIndex("dbo.Courses", new[] { "Institute_Id" });
            DropIndex("dbo.Courses", new[] { "Discipline_Id" });
            DropTable("dbo.Institutes");
            DropTable("dbo.Districts");
            DropTable("dbo.Exams");
            DropTable("dbo.Disciplines");
            DropTable("dbo.Courses");
            DropTable("dbo.Cities");
        }
    }
}
