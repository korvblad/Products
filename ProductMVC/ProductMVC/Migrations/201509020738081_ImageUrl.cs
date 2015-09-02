namespace ProductMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageUrl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ImageUrl", c => c.String());
            AddColumn("dbo.Products", "CategoryId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "CategoryId");
            DropColumn("dbo.Products", "ImageUrl");
        }
    }
}
