namespace Shedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB : DbMigration
    {
        public override void Up()
        {
            
            
            
            
           
            
            
            
            CreateTable(
                "dbo.Cycles_item",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectId = c.Int(nullable: false),
                        Hours = c.Int(),
                        CyclesId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cycles", t => t.CyclesId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectId)
                .Index(t => t.CyclesId);
            
            
            
           
            
        }
        
        public override void Down()
        {
           
            DropForeignKey("dbo.Cycles_item", "Subjects_Id", "dbo.Subjects");
            DropForeignKey("dbo.Cycles_item", "CyclesId", "dbo.Cycles");
           
           
            DropIndex("dbo.Cycles_item", new[] { "Subjects_Id" });
            DropIndex("dbo.Cycles_item", new[] { "CyclesId" });
           
           
            DropTable("dbo.Cycles_item");
            
            
        }
    }
}
