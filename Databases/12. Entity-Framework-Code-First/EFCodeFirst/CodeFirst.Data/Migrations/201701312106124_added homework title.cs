namespace CodeFirst.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedhomeworktitle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Homework", "Title", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Homework", "Title");
        }
    }
}
