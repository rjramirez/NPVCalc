namespace NPVCalc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NPV",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LowerBoundDiscountRate = c.Double(nullable: false),
                        UpperBoundDiscountRate = c.Double(nullable: false),
                        DiscountRateIncrement = c.Double(nullable: false),
                        CashFlows = c.String(),
                        DateModified = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.NPVItemResult",
                c => new
                    {
                        NPVItemResultId = c.Int(nullable: false, identity: true),
                        NPVId = c.Int(nullable: false),
                        Period = c.Int(nullable: false),
                        NPVResult = c.Double(nullable: false),
                        Discount = c.Double(nullable: false),
                        CashFlow = c.String(),
                    })
                .PrimaryKey(t => t.NPVItemResultId)
                .ForeignKey("dbo.NPV", t => t.NPVId, cascadeDelete: true)
                .Index(t => t.NPVId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NPVItemResult", "NPVId", "dbo.NPV");
            DropIndex("dbo.NPVItemResult", new[] { "NPVId" });
            DropTable("dbo.NPVItemResult");
            DropTable("dbo.NPV");
        }
    }
}
