namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CurrentWeathers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Temperature = c.Single(nullable: false),
                        Humidity = c.Int(nullable: false),
                        Condition = c.String(),
                        Timestamp = c.DateTime(nullable: false),
                        LocationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true)
                .Index(t => t.LocationId);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CityName = c.String(),
                        CountryCode = c.String(),
                        Latitude = c.Single(nullable: false),
                        Longitude = c.Single(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        PasswordHash = c.String(),
                        Email = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WeatherAlerts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AlertType = c.String(),
                        AlertMessage = c.String(),
                        IssuedAt = c.DateTime(nullable: false),
                        ExpiresAt = c.DateTime(),
                        LocationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true)
                .Index(t => t.LocationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CurrentWeathers", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.WeatherAlerts", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.Locations", "UserId", "dbo.Users");
            DropIndex("dbo.WeatherAlerts", new[] { "LocationId" });
            DropIndex("dbo.Locations", new[] { "UserId" });
            DropIndex("dbo.CurrentWeathers", new[] { "LocationId" });
            DropTable("dbo.WeatherAlerts");
            DropTable("dbo.Users");
            DropTable("dbo.Locations");
            DropTable("dbo.CurrentWeathers");
        }
    }
}
