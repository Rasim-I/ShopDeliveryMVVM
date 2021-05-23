namespace ShopData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        EstOrdDeliveryTime = c.DateTime(nullable: false),
                        name = c.String(),
                        place_Id = c.Guid(),
                        product_Id = c.Guid(),
                        transport_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Places", t => t.place_Id)
                .ForeignKey("dbo.Products", t => t.product_Id)
                .ForeignKey("dbo.Transports", t => t.transport_Id)
                .Index(t => t.place_Id)
                .Index(t => t.product_Id)
                .Index(t => t.transport_Id);
            
            CreateTable(
                "dbo.Places",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        distance = c.Int(nullable: false),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        quantity = c.Int(nullable: false),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Transports",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        capacity = c.Int(nullable: false),
                        speed = c.Int(nullable: false),
                        state = c.Int(nullable: false),
                        TimeUntilFree = c.Time(nullable: false, precision: 7),
                        name = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "transport_Id", "dbo.Transports");
            DropForeignKey("dbo.Orders", "product_Id", "dbo.Products");
            DropForeignKey("dbo.Orders", "place_Id", "dbo.Places");
            DropIndex("dbo.Orders", new[] { "transport_Id" });
            DropIndex("dbo.Orders", new[] { "product_Id" });
            DropIndex("dbo.Orders", new[] { "place_Id" });
            DropTable("dbo.Transports");
            DropTable("dbo.Products");
            DropTable("dbo.Places");
            DropTable("dbo.Orders");
        }
    }
}
