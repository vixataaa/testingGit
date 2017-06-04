namespace PollSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FluentApi1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cities", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Countries", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Users", "Username", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.Cities", "Name", name: "IX_Cityname");
            CreateIndex("dbo.Countries", "Name", name: "IX_Countryname");
            CreateIndex("dbo.Users", "Username");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "Username" });
            DropIndex("dbo.Countries", "IX_Countryname");
            DropIndex("dbo.Cities", "IX_Cityname");
            AlterColumn("dbo.Users", "Username", c => c.String());
            AlterColumn("dbo.Countries", "Name", c => c.String());
            AlterColumn("dbo.Cities", "Name", c => c.String());
        }
    }
}
