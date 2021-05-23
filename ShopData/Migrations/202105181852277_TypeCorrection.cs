namespace ShopData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TypeCorrection : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "size", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "type", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "weight", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "weight");
            DropColumn("dbo.Products", "type");
            DropColumn("dbo.Products", "size");
        }
    }
}
