namespace PropertiesReader.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class creating_more_tables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PropertiesModels", "PropertyList_Id", "dbo.PropertyLists");
            DropIndex("dbo.PropertiesModels", new[] { "PropertyList_Id" });
            DropColumn("dbo.PropertiesModels", "PropertyList_Id");
            DropTable("dbo.PropertyLists");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PropertyLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.PropertiesModels", "PropertyList_Id", c => c.Int());
            CreateIndex("dbo.PropertiesModels", "PropertyList_Id");
            AddForeignKey("dbo.PropertiesModels", "PropertyList_Id", "dbo.PropertyLists", "Id");
        }
    }
}
