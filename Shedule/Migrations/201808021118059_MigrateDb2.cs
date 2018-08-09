namespace Shedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDb2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cycles_item", "CyclesId", "dbo.Cycles");
            DropIndex("dbo.Cycles_item", new[] { "CyclesId" });
            AlterColumn("dbo.Cycles_item", "SubjectId", c => c.Int());
            AlterColumn("dbo.Cycles_item", "CyclesId", c => c.Int());
            CreateIndex("dbo.Cycles_item", "CyclesId");
            AddForeignKey("dbo.Cycles_item", "CyclesId", "dbo.Cycles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cycles_item", "CyclesId", "dbo.Cycles");
            DropIndex("dbo.Cycles_item", new[] { "CyclesId" });
            AlterColumn("dbo.Cycles_item", "CyclesId", c => c.Int(nullable: false));
            AlterColumn("dbo.Cycles_item", "SubjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.Cycles_item", "CyclesId");
            AddForeignKey("dbo.Cycles_item", "CyclesId", "dbo.Cycles", "Id", cascadeDelete: true);
        }
    }
}
