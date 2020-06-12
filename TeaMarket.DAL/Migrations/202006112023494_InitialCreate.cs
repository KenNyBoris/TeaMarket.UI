namespace TeaMarket.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Surname = c.String(),
                        City = c.String(),
                        Address = c.String(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DeliveryMethod = c.Int(nullable: false),
                        PayMethod = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Customer_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Order_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.Order_Id)
                .Index(t => t.Order_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Orders", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Products", new[] { "Order_Id" });
            DropIndex("dbo.Orders", new[] { "Customer_Id" });
            DropTable("dbo.Products");
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
        }
    }
}
