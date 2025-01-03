namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CurrentWeathers", "Condition", c => c.String(nullable: false));
            AlterColumn("dbo.Locations", "CityName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Locations", "CountryCode", c => c.String(nullable: false, maxLength: 5));
            AlterColumn("dbo.DailyForecasts", "Condition", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Username", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.WeatherAlerts", "AlertType", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.WeatherAlerts", "AlertMessage", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WeatherAlerts", "AlertMessage", c => c.String());
            AlterColumn("dbo.WeatherAlerts", "AlertType", c => c.String());
            AlterColumn("dbo.Users", "Email", c => c.String());
            AlterColumn("dbo.Users", "Password", c => c.String());
            AlterColumn("dbo.Users", "Username", c => c.String());
            AlterColumn("dbo.DailyForecasts", "Condition", c => c.String());
            AlterColumn("dbo.Locations", "CountryCode", c => c.String());
            AlterColumn("dbo.Locations", "CityName", c => c.String());
            AlterColumn("dbo.CurrentWeathers", "Condition", c => c.String());
        }
    }
}
