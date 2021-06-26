namespace ShopData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransportFix : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        OrderTime = c.DateTime(nullable: false),
                        State = c.Int(nullable: false),
                        TransportId = c.Guid(nullable: false),
                        PlaceId = c.Guid(nullable: false),
                        ProductId = c.Guid(nullable: false),
                        Customer = c.String(),
                        EstOrdDeliveryTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Places", t => t.PlaceId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Transports", t => t.TransportId, cascadeDelete: true)
                .Index(t => t.TransportId)
                .Index(t => t.PlaceId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Places",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        name = c.String(),
                        distance = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        name = c.String(),
                        size = c.Int(nullable: false),
                        type = c.Int(nullable: false),
                        Weight = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Transports",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        name = c.String(),
                        capacity = c.Int(nullable: false),
                        speed = c.Int(nullable: false),
                        state = c.Int(nullable: false),
                        TimeUntilFree = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BalancedTransports",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Transports", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.CapaciousTransports",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Transports", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.FastTransports",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Transports", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FastTransports", "Id", "dbo.Transports");
            DropForeignKey("dbo.CapaciousTransports", "Id", "dbo.Transports");
            DropForeignKey("dbo.BalancedTransports", "Id", "dbo.Transports");
            DropForeignKey("dbo.Orders", "TransportId", "dbo.Transports");
            DropForeignKey("dbo.Orders", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Orders", "PlaceId", "dbo.Places");
            DropIndex("dbo.FastTransports", new[] { "Id" });
            DropIndex("dbo.CapaciousTransports", new[] { "Id" });
            DropIndex("dbo.BalancedTransports", new[] { "Id" });
            DropIndex("dbo.Orders", new[] { "ProductId" });
            DropIndex("dbo.Orders", new[] { "PlaceId" });
            DropIndex("dbo.Orders", new[] { "TransportId" });
            DropTable("dbo.FastTransports");
            DropTable("dbo.CapaciousTransports");
            DropTable("dbo.BalancedTransports");
            DropTable("dbo.Transports");
            DropTable("dbo.Products");
            DropTable("dbo.Places");
            DropTable("dbo.Orders");
        }
    }
}
