namespace fh_family_experience_code_first_database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialsetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccessibilityForDisabilities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Accessibility = c.String(),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(),
                        LastUpdatedBy = c.String(),
                        LastUpdated = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Latitude = c.Double(),
                        Longitude = c.Double(),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(),
                        LastUpdatedBy = c.String(),
                        LastUpdated = c.DateTime(),
                        AccessibilityForDisabilities_Id = c.Guid(),
                        ServiceAtLocation_Id = c.Guid(),
                        PhysicalAddress_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccessibilityForDisabilities", t => t.AccessibilityForDisabilities_Id)
                .ForeignKey("dbo.ServiceAtLocations", t => t.ServiceAtLocation_Id)
                .ForeignKey("dbo.PhysicalAddresses", t => t.PhysicalAddress_Id)
                .Index(t => t.AccessibilityForDisabilities_Id)
                .Index(t => t.ServiceAtLocation_Id)
                .Index(t => t.PhysicalAddress_Id);
            
            CreateTable(
                "dbo.HolidaySchedules",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Closed = c.Boolean(),
                        OpensAt = c.DateTime(),
                        ClosesAt = c.DateTime(),
                        SatrtDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(),
                        LastUpdatedBy = c.String(),
                        LastUpdated = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ServiceAtLocations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(),
                        LastUpdatedBy = c.String(),
                        LastUpdated = c.DateTime(),
                        HolidaySchedule_Id = c.Guid(),
                        RegularSchedule_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HolidaySchedules", t => t.HolidaySchedule_Id)
                .ForeignKey("dbo.RegularSchedules", t => t.RegularSchedule_Id)
                .Index(t => t.HolidaySchedule_Id)
                .Index(t => t.RegularSchedule_Id);
            
            CreateTable(
                "dbo.ServiceItems",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Email = c.String(),
                        Url = c.String(),
                        Status = c.Int(),
                        Fees = c.String(),
                        Accreditations = c.String(),
                        DeliverableType = c.Int(),
                        AssuredDate = c.DateTime(),
                        AttendingType = c.Int(),
                        AttendingAccess = c.Int(),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(),
                        LastUpdatedBy = c.String(),
                        LastUpdated = c.DateTime(),
                        ServiceAtLocation_Id = c.Guid(),
                        HolidaySchedule_Id = c.Guid(),
                        RegularSchedule_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceAtLocations", t => t.ServiceAtLocation_Id)
                .ForeignKey("dbo.HolidaySchedules", t => t.HolidaySchedule_Id)
                .ForeignKey("dbo.RegularSchedules", t => t.RegularSchedule_Id)
                .Index(t => t.ServiceAtLocation_Id)
                .Index(t => t.HolidaySchedule_Id)
                .Index(t => t.RegularSchedule_Id);
            
            CreateTable(
                "dbo.Organisations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Email = c.String(),
                        Url = c.String(),
                        Logo = c.String(),
                        LogoUrl = c.String(),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(),
                        LastUpdatedBy = c.String(),
                        LastUpdated = c.DateTime(),
                        ServiceItem_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceItems", t => t.ServiceItem_Id)
                .Index(t => t.ServiceItem_Id);
            
            CreateTable(
                "dbo.PhysicalAddresses",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Address1 = c.String(),
                        City = c.String(),
                        StateProvince = c.String(),
                        Postcode = c.String(),
                        Country = c.String(),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(),
                        LastUpdatedBy = c.String(),
                        LastUpdated = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RegularSchedules",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        WeekDay = c.Int(),
                        OpensAt = c.DateTime(),
                        ClosesAt = c.DateTime(),
                        ValidFrom = c.DateTime(),
                        ValidTo = c.DateTime(),
                        DtStart = c.DateTime(),
                        Frequency = c.Int(),
                        Interval = c.Int(),
                        ByDay = c.String(),
                        ByMonthDay = c.Int(),
                        Description = c.String(),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(),
                        LastUpdatedBy = c.String(),
                        LastUpdated = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServiceItems", "RegularSchedule_Id", "dbo.RegularSchedules");
            DropForeignKey("dbo.ServiceAtLocations", "RegularSchedule_Id", "dbo.RegularSchedules");
            DropForeignKey("dbo.Locations", "PhysicalAddress_Id", "dbo.PhysicalAddresses");
            DropForeignKey("dbo.ServiceItems", "HolidaySchedule_Id", "dbo.HolidaySchedules");
            DropForeignKey("dbo.ServiceAtLocations", "HolidaySchedule_Id", "dbo.HolidaySchedules");
            DropForeignKey("dbo.ServiceItems", "ServiceAtLocation_Id", "dbo.ServiceAtLocations");
            DropForeignKey("dbo.Organisations", "ServiceItem_Id", "dbo.ServiceItems");
            DropForeignKey("dbo.Locations", "ServiceAtLocation_Id", "dbo.ServiceAtLocations");
            DropForeignKey("dbo.Locations", "AccessibilityForDisabilities_Id", "dbo.AccessibilityForDisabilities");
            DropIndex("dbo.Organisations", new[] { "ServiceItem_Id" });
            DropIndex("dbo.ServiceItems", new[] { "RegularSchedule_Id" });
            DropIndex("dbo.ServiceItems", new[] { "HolidaySchedule_Id" });
            DropIndex("dbo.ServiceItems", new[] { "ServiceAtLocation_Id" });
            DropIndex("dbo.ServiceAtLocations", new[] { "RegularSchedule_Id" });
            DropIndex("dbo.ServiceAtLocations", new[] { "HolidaySchedule_Id" });
            DropIndex("dbo.Locations", new[] { "PhysicalAddress_Id" });
            DropIndex("dbo.Locations", new[] { "ServiceAtLocation_Id" });
            DropIndex("dbo.Locations", new[] { "AccessibilityForDisabilities_Id" });
            DropTable("dbo.RegularSchedules");
            DropTable("dbo.PhysicalAddresses");
            DropTable("dbo.Organisations");
            DropTable("dbo.ServiceItems");
            DropTable("dbo.ServiceAtLocations");
            DropTable("dbo.HolidaySchedules");
            DropTable("dbo.Locations");
            DropTable("dbo.AccessibilityForDisabilities");
        }
    }
}
