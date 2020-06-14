namespace RepositeryLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableCheckout : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CheckoutTable",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        Zipcode = c.Int(nullable: false),
                        State = c.String(),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CheckoutTable");
        }
    }
}
