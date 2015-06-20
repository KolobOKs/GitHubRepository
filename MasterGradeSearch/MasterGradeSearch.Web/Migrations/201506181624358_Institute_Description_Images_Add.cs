namespace MasterGradeSearch.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Institute_Description_Images_Add : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Institutes", "Description", c => c.String());
            AddColumn("dbo.Institutes", "ImageBase64", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Institutes", "ImageBase64");
            DropColumn("dbo.Institutes", "Description");
        }
    }
}
