namespace Megazinde.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenametarihToresimInHaberlersTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Haberlers", "resim", c => c.String());
            DropColumn("dbo.Haberlers", "tarih");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Haberlers", "tarih", c => c.String());
            DropColumn("dbo.Haberlers", "resim");
        }
    }
}
