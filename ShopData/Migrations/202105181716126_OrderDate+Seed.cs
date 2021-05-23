namespace ShopData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderDateSeed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "order_time", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "order_time");
        }
    }
}
