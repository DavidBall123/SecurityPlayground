namespace SecurityPlaygroundApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Certificate",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Acronym = c.String(),
                        Organisation = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subject",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CertificateId = c.Int(nullable: false),
                        Name = c.String(),
                        Weight = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Certificate", t => t.CertificateId, cascadeDelete: true)
                .Index(t => t.CertificateId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subject", "CertificateId", "dbo.Certificate");
            DropIndex("dbo.Subject", new[] { "CertificateId" });
            DropTable("dbo.Subject");
            DropTable("dbo.Certificate");
        }
    }
}
