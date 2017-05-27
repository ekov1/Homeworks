namespace CodeFirst.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateStudentClass : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "StudentNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "Age", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "Age", c => c.String());
            AlterColumn("dbo.Students", "StudentNumber", c => c.String());
        }
    }
}
