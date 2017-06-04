namespace PollSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FluentApi3 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Countries", "IX_Countryname");
            CreateIndex("dbo.Countries", "Name", unique: true, name: "IX_Countryname");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Countries", "IX_Countryname");
            CreateIndex("dbo.Countries", "Name", name: "IX_Countryname");
        }
    }
}
