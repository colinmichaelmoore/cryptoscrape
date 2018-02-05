namespace crypto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Currencies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(),
                        Name = c.String(),
                        Symbol = c.String(),
                        Market = c.String(),
                        Price = c.String(),
                        Supply = c.String(),
                        Volume = c.String(),
                        Hour = c.String(),
                        Day = c.String(),
                        Week = c.String(),
                        DateTime = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Currencies");
        }
    }
}
