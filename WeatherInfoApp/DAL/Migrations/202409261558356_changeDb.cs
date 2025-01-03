namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeDb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Password", c => c.String());
            DropColumn("dbo.CurrentWeathers", "Timestamp");
            DropColumn("dbo.Users", "PasswordHash");
            DropColumn("dbo.Users", "CreatedAt");
            DropColumn("dbo.Users", "IsActive");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "PasswordHash", c => c.String());
            AddColumn("dbo.CurrentWeathers", "Timestamp", c => c.DateTime(nullable: false));
            DropColumn("dbo.Users", "Password");
        }
    }
}
