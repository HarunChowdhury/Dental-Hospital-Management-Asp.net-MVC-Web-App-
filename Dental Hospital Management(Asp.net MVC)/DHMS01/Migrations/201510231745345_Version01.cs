namespace DHMS01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version01 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Today = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AppointmentCreates",
                c => new
                    {
                        AppointmentCreateId = c.Int(nullable: false, identity: true),
                        TimeId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Serial = c.String(),
                        PatientName = c.String(),
                        PhonNum = c.String(),
                        AppId = c.Int(nullable: false),
                        ProblemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AppointmentCreateId)
                .ForeignKey("dbo.AppTypes", t => t.AppId, cascadeDelete: true)
                .ForeignKey("dbo.Problems", t => t.ProblemId, cascadeDelete: true)
                .ForeignKey("dbo.Times", t => t.TimeId, cascadeDelete: true)
                .Index(t => t.AppId)
                .Index(t => t.ProblemId)
                .Index(t => t.TimeId);
            
            CreateTable(
                "dbo.AppTypes",
                c => new
                    {
                        AppId = c.Int(nullable: false, identity: true),
                        AppType1 = c.String(),
                    })
                .PrimaryKey(t => t.AppId);
            
            CreateTable(
                "dbo.Problems",
                c => new
                    {
                        ProblemId = c.Int(nullable: false, identity: true),
                        Problem1 = c.String(),
                    })
                .PrimaryKey(t => t.ProblemId);
            
            CreateTable(
                "dbo.Times",
                c => new
                    {
                        TimeId = c.Int(nullable: false, identity: true),
                        Time1 = c.String(),
                    })
                .PrimaryKey(t => t.TimeId);
            
            CreateTable(
                "dbo.Ats",
                c => new
                    {
                        AtId = c.Int(nullable: false, identity: true),
                        AtName = c.String(),
                    })
                .PrimaryKey(t => t.AtId);
            
            CreateTable(
                "dbo.ChiefComplains",
                c => new
                    {
                        ChiefComplainId = c.Int(nullable: false, identity: true),
                        Complain = c.String(),
                        Duration = c.Int(nullable: false),
                        Reason = c.String(),
                        Comment = c.String(),
                        ComplainId = c.Int(nullable: false),
                        AtId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ChiefComplainId)
                .ForeignKey("dbo.Ats", t => t.AtId, cascadeDelete: true)
                .ForeignKey("dbo.Complains", t => t.ComplainId, cascadeDelete: true)
                .Index(t => t.AtId)
                .Index(t => t.ComplainId);
            
            CreateTable(
                "dbo.Complains",
                c => new
                    {
                        ComplainId = c.Int(nullable: false, identity: true),
                        ComplainName = c.String(),
                    })
                .PrimaryKey(t => t.ComplainId);
            
            CreateTable(
                "dbo.PatientPersonalInfoes",
                c => new
                    {
                        PatientPersonalInfoId = c.Int(nullable: false, identity: true),
                        EntryDate = c.DateTime(nullable: false),
                        PatientId = c.String(),
                        Name = c.String(),
                        Sex = c.Int(nullable: false),
                        Dob = c.DateTime(nullable: false),
                        PatientAge = c.Int(nullable: false),
                        FatherName = c.String(),
                        MotherName = c.String(),
                        MaritalStatus = c.Int(nullable: false),
                        SpouseName = c.String(),
                        PresentAddress = c.String(),
                        MobilePhone = c.String(),
                        Email = c.String(),
                        Occupation = c.String(),
                        Designation = c.String(),
                        ReferredBy = c.String(),
                    })
                .PrimaryKey(t => t.PatientPersonalInfoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChiefComplains", "ComplainId", "dbo.Complains");
            DropForeignKey("dbo.ChiefComplains", "AtId", "dbo.Ats");
            DropForeignKey("dbo.AppointmentCreates", "TimeId", "dbo.Times");
            DropForeignKey("dbo.AppointmentCreates", "ProblemId", "dbo.Problems");
            DropForeignKey("dbo.AppointmentCreates", "AppId", "dbo.AppTypes");
            DropIndex("dbo.ChiefComplains", new[] { "ComplainId" });
            DropIndex("dbo.ChiefComplains", new[] { "AtId" });
            DropIndex("dbo.AppointmentCreates", new[] { "TimeId" });
            DropIndex("dbo.AppointmentCreates", new[] { "ProblemId" });
            DropIndex("dbo.AppointmentCreates", new[] { "AppId" });
            DropTable("dbo.PatientPersonalInfoes");
            DropTable("dbo.Complains");
            DropTable("dbo.ChiefComplains");
            DropTable("dbo.Ats");
            DropTable("dbo.Times");
            DropTable("dbo.Problems");
            DropTable("dbo.AppTypes");
            DropTable("dbo.AppointmentCreates");
            DropTable("dbo.Appointments");
        }
    }
}
