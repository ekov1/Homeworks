namespace CodeFirst.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Homework",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false),
                        TimeSent = c.DateTime(nullable: false),
                        Courses_Id = c.Int(),
                        Students_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.Courses_Id)
                .ForeignKey("dbo.Students", t => t.Students_Id)
                .Index(t => t.Courses_Id)
                .Index(t => t.Students_Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        StudentNumber = c.String(),
                        Age = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentsCourses",
                c => new
                    {
                        Students_Id = c.Int(nullable: false),
                        Courses_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Students_Id, t.Courses_Id })
                .ForeignKey("dbo.Students", t => t.Students_Id, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Courses_Id, cascadeDelete: true)
                .Index(t => t.Students_Id)
                .Index(t => t.Courses_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Homework", "Students_Id", "dbo.Students");
            DropForeignKey("dbo.StudentsCourses", "Courses_Id", "dbo.Courses");
            DropForeignKey("dbo.StudentsCourses", "Students_Id", "dbo.Students");
            DropForeignKey("dbo.Homework", "Courses_Id", "dbo.Courses");
            DropIndex("dbo.StudentsCourses", new[] { "Courses_Id" });
            DropIndex("dbo.StudentsCourses", new[] { "Students_Id" });
            DropIndex("dbo.Homework", new[] { "Students_Id" });
            DropIndex("dbo.Homework", new[] { "Courses_Id" });
            DropTable("dbo.StudentsCourses");
            DropTable("dbo.Students");
            DropTable("dbo.Homework");
            DropTable("dbo.Courses");
        }
    }
}
