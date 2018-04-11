namespace MockInterviewApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RegistrationPhoneNumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "RegistrationPhoneNumber", c => c.String());
            DropColumn("dbo.AspNetUsers", "Number");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Number", c => c.String());
            DropColumn("dbo.AspNetUsers", "RegistrationPhoneNumber");
        }
    }
}
