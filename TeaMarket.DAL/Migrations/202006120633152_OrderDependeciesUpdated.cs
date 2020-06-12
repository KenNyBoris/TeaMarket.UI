namespace TeaMarket.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderDependeciesUpdated : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Orders", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "Customer_Id" });
            DropIndex("dbo.Products", new[] { "Order_Id" });
            RenameColumn(table: "dbo.Orders", name: "Customer_Id", newName: "CustomerId");
            AddColumn("dbo.Orders", "ProductId", c => c.Guid(nullable: false));
            AddColumn("dbo.Orders", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "TotalCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Orders", "CustomerId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Orders", "ProductId");
            CreateIndex("dbo.Orders", "CustomerId");
            AddForeignKey("dbo.Orders", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
            DropColumn("dbo.Products", "Order_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Order_Id", c => c.Guid());
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Orders", "ProductId", "dbo.Products");
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropIndex("dbo.Orders", new[] { "ProductId" });
            AlterColumn("dbo.Orders", "CustomerId", c => c.Guid());
            DropColumn("dbo.Orders", "TotalCost");
            DropColumn("dbo.Orders", "Quantity");
            DropColumn("dbo.Orders", "ProductId");
            RenameColumn(table: "dbo.Orders", name: "CustomerId", newName: "Customer_Id");
            CreateIndex("dbo.Products", "Order_Id");
            CreateIndex("dbo.Orders", "Customer_Id");
            AddForeignKey("dbo.Orders", "Customer_Id", "dbo.Customers", "Id");
            AddForeignKey("dbo.Products", "Order_Id", "dbo.Orders", "Id");
        }
    }
}
