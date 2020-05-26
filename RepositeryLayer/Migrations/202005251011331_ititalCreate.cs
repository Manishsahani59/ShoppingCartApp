namespace RepositeryLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ititalCreate : DbMigration
    {
        public override void Up()
        {
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
        }
    }
}
