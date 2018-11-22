namespace GeneralKnowledge.Test.App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assets",
                c => new
                    {
                        asset_id = c.Guid(nullable: false),
                        file_name = c.String(nullable: false, maxLength: 255),
                        mime_type = c.String(nullable: false, maxLength: 255),
                        created_by = c.String(nullable: false, maxLength: 255),
                        email = c.String(nullable: false, maxLength: 255),
                        country = c.String(nullable: false, maxLength: 255),
                        description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.asset_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Assets");
        }
    }
}
