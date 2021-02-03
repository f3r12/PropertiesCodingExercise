namespace PropertiesReader.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PropertiesModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address_Address1 = c.String(),
                        Address_Address2 = c.String(),
                        Address_City = c.String(),
                        Address_Country = c.String(),
                        Address_County = c.String(),
                        Address_District = c.String(),
                        Address_State = c.String(),
                        Address_Zip = c.String(),
                        Address_ZipPlus4 = c.String(),
                        Physical_YearBuilt = c.Int(nullable: false),
                        Financial_ListPrice = c.Long(nullable: false),
                        Financial_MonthlyRent = c.Long(nullable: false),
                        Financial_GrossYield = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PropertiesModels");
        }
    }
}
