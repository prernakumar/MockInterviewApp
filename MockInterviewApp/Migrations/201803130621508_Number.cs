namespace MockInterviewApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Number : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Number", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Number");
        }
    }
}
