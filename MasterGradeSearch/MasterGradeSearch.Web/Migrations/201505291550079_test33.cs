namespace MasterGradeSearch.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test33 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Exams", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.CoursesToExamMapping", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.CoursesToExamMapping", "ExamId", "dbo.Exams");
            DropIndex("dbo.Exams", new[] { "Course_Id" });
            DropPrimaryKey("dbo.Courses");
            DropPrimaryKey("dbo.Exams");
            CreateTable(
                "dbo.CoursesToExamMapping",
                c => new
                    {
                        CourseId = c.Int(nullable: false),
                        ExamId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CourseId, t.ExamId })
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Exams", t => t.ExamId, cascadeDelete: true)
                .Index(t => t.CourseId)
                .Index(t => t.ExamId);

            DropColumn("dbo.Courses", "Id");
            DropColumn("dbo.Exams", "Id");
            DropColumn("dbo.Exams", "Course_Id");
            AddColumn("dbo.Courses", "CourseId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Exams", "ExamId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Courses", "CourseId");
            AddPrimaryKey("dbo.Exams", "ExamId");

        }
        
        public override void Down()
        {
            AddColumn("dbo.Exams", "Course_Id", c => c.Int());
            AddColumn("dbo.Exams", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Courses", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.CoursesToExamMapping", "ExamId", "dbo.Exams");
            DropForeignKey("dbo.CoursesToExamMapping", "CourseId", "dbo.Courses");
            DropIndex("dbo.CoursesToExamMapping", new[] { "ExamId" });
            DropIndex("dbo.CoursesToExamMapping", new[] { "CourseId" });
            DropPrimaryKey("dbo.Exams");
            DropPrimaryKey("dbo.Courses");
            DropColumn("dbo.Exams", "ExamId");
            DropColumn("dbo.Courses", "CourseId");
            DropTable("dbo.CoursesToExamMapping");
            AddPrimaryKey("dbo.Exams", "Id");
            AddPrimaryKey("dbo.Courses", "Id");
            CreateIndex("dbo.Exams", "Course_Id");
            AddForeignKey("dbo.CoursesToExamMapping", "ExamId", "dbo.Exams", "ExamId", cascadeDelete: true);
            AddForeignKey("dbo.CoursesToExamMapping", "CourseId", "dbo.Courses", "CourseId", cascadeDelete: true);
            AddForeignKey("dbo.Exams", "Course_Id", "dbo.Courses", "Id");
        }
    }
}
