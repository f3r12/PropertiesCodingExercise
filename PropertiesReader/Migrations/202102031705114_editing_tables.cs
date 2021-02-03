namespace PropertiesReader.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editing_tables : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.PropertiesModels", newName: "Properties");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Properties", newName: "PropertiesModels");
        }
    }
}
