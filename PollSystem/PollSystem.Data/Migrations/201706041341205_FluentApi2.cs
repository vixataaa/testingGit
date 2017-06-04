namespace PollSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FluentApi2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Cities", "IX_Cityname");
            DropIndex("dbo.Users", new[] { "Username" });
            CreateIndex("dbo.Cities", "Name", unique: true, name: "IX_Cityname");
            CreateIndex("dbo.Users", "Username", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "Username" });
            DropIndex("dbo.Cities", "IX_Cityname");
            CreateIndex("dbo.Users", "Username");
            CreateIndex("dbo.Cities", "Name", name: "IX_Cityname");
        }
    }
}
