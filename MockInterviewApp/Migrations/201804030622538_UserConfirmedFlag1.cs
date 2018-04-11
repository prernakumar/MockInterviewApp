namespace MockInterviewApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserConfirmedFlag1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "UserConfirmedFlag", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "UserConfirmedFlag");
        }
    }
}
