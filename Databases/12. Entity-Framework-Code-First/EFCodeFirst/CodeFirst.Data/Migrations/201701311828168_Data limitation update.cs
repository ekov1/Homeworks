namespace CodeFirst.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Datalimitationupdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Courses", "Description", c => c.String(maxLength: 200));
            AlterColumn("dbo.Homework", "Content", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Students", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Students", "StudentNumber", c => c.String(nullable: false, maxLength: 15));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "StudentNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Homework", "Content", c => c.String(nullable: false));
            AlterColumn("dbo.Courses", "Description", c => c.String());
            AlterColumn("dbo.Courses", "Name", c => c.String(nullable: false));
        }
    }
}
