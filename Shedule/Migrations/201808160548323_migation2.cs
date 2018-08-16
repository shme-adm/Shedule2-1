namespace Shedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migation2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Buildings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Comment = c.String(),
                        CitiesId = c.Int(),
                        UnitsId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CitiesId)
                .ForeignKey("dbo.Units", t => t.UnitsId)
                .Index(t => t.CitiesId)
                .Index(t => t.UnitsId);
            
            CreateTable(
                "dbo.Cabinets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Comment = c.String(),
                        Lecture = c.Boolean(nullable: false),
                        Practice = c.Boolean(nullable: false),
                        BuildingsId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Buildings", t => t.BuildingsId)
                .Index(t => t.BuildingsId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DateFrom = c.DateTime(nullable: false),
                        DateTo = c.DateTime(nullable: false),
                        QuantitySubGroups = c.Int(),
                        Budget = c.Boolean(nullable: false),
                        CyclesId = c.Int(),
                        CityId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId)
                .ForeignKey("dbo.Cycles", t => t.CyclesId)
                .Index(t => t.CyclesId)
                .Index(t => t.CityId);
            
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
                        SubjectsGroupsId = c.Int(),
                        CyclesId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cycles", t => t.CyclesId)
                .Index(t => t.CyclesId);
            
            CreateTable(
                "dbo.Units",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CitiesId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CitiesId)
                .Index(t => t.CitiesId);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Subjects_groupsId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subjects_groups", t => t.Subjects_groupsId)
                .Index(t => t.Subjects_groupsId);
            
            CreateTable(
                "dbo.Subjects_groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Middlename = c.String(),
                        Comment = c.String(),
                        Staff = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TypeOfClasses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Guid = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subjects", "Subjects_groupsId", "dbo.Subjects_groups");
            DropForeignKey("dbo.Units", "CitiesId", "dbo.Cities");
            DropForeignKey("dbo.Buildings", "UnitsId", "dbo.Units");
            DropForeignKey("dbo.Groups", "CyclesId", "dbo.Cycles");
            DropForeignKey("dbo.Cycles_item", "CyclesId", "dbo.Cycles");
            DropForeignKey("dbo.Groups", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Buildings", "CitiesId", "dbo.Cities");
            DropForeignKey("dbo.Cabinets", "BuildingsId", "dbo.Buildings");
            DropIndex("dbo.Subjects", new[] { "Subjects_groupsId" });
            DropIndex("dbo.Units", new[] { "CitiesId" });
            DropIndex("dbo.Cycles_item", new[] { "CyclesId" });
            DropIndex("dbo.Groups", new[] { "CityId" });
            DropIndex("dbo.Groups", new[] { "CyclesId" });
            DropIndex("dbo.Cabinets", new[] { "BuildingsId" });
            DropIndex("dbo.Buildings", new[] { "UnitsId" });
            DropIndex("dbo.Buildings", new[] { "CitiesId" });
            DropTable("dbo.TypeOfClasses");
            DropTable("dbo.Teachers");
            DropTable("dbo.Subjects_groups");
            DropTable("dbo.Subjects");
            DropTable("dbo.Units");
            DropTable("dbo.Cycles_item");
            DropTable("dbo.Cycles");
            DropTable("dbo.Groups");
            DropTable("dbo.Cities");
            DropTable("dbo.Cabinets");
            DropTable("dbo.Buildings");
        }
    }
}
