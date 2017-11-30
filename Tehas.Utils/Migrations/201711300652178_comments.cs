namespace Klinik.Utils.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class comments : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "Image_Id", c => c.Int());
            CreateIndex("dbo.Comments", "Image_Id");
            AddForeignKey("dbo.Comments", "Image_Id", "dbo.Images", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "Image_Id", "dbo.Images");
            DropIndex("dbo.Comments", new[] { "Image_Id" });
            DropColumn("dbo.Comments", "Image_Id");
        }
    }
}
