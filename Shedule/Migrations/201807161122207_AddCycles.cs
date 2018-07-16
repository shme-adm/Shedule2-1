namespace Shedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCycles : DbMigration
    {
        public override void Up()
        {            
            CreateTable(
                "dbo.Cycles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cycles_item",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Hours = c.Int(),
                        CyclesId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cycles", t => t.CyclesId)
                .Index(t => t.CyclesId);
            
            
            
        }
        
        public override void Down()
        {
            
            DropForeignKey("dbo.Cycles_item", "CyclesId", "dbo.Cycles");           
            DropIndex("dbo.Cycles_item", new[] { "CyclesId" });            
            DropTable("dbo.Cycles_item");
            DropTable("dbo.Cycles");
           
        }
    }
}
