namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHourlyandDailyForcastDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DailyForecasts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ForecastDate = c.DateTime(nullable: false),
                        MinTemperature = c.Single(nullable: false),
                        MaxTemperature = c.Single(nullable: false),
                        Condition = c.String(),
                        LocationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true)
                .Index(t => t.LocationId);
            
            CreateTable(
                "dbo.HourlyForecasts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ForecastDateTime = c.DateTime(nullable: false),
                        Temperature = c.Single(nullable: false),
                        Condition = c.String(),
                        LocationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true)
                .Index(t => t.LocationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HourlyForecasts", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.DailyForecasts", "LocationId", "dbo.Locations");
            DropIndex("dbo.HourlyForecasts", new[] { "LocationId" });
            DropIndex("dbo.DailyForecasts", new[] { "LocationId" });
            DropTable("dbo.HourlyForecasts");
            DropTable("dbo.DailyForecasts");
        }
    }
}
