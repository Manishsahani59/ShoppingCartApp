namespace RepositeryLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntitalCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderedProduct",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        isDeleted = c.Boolean(nullable: false),
                        OrderedDate = c.DateTime(nullable: false),
                        ModefyDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Image = c.String(),
                        Quantity = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        createAt = c.DateTime(nullable: false),
                        ModefyAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Products");
            DropTable("dbo.OrderedProduct");
        }
    }
}
