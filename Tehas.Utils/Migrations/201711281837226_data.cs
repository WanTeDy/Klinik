namespace Klinik.Utils.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class data : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Categories", "ParentId", "dbo.Categories");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.PageDescriptionImages", "PageDescription_Id", "dbo.PageDescriptions");
            DropForeignKey("dbo.PageDescriptionImages", "Image_Id", "dbo.Images");
            DropForeignKey("dbo.OrderGames", "Game_Id", "dbo.Games");
            DropForeignKey("dbo.Games", "ParrentId", "dbo.Games");
            DropForeignKey("dbo.OrderGames", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.OrderProducts", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Orders", "UserEmailMessage_Id", "dbo.UserEmailMessages");
            DropForeignKey("dbo.OrderProducts", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Products", "ImageId", "dbo.Images");
            DropIndex("dbo.Categories", new[] { "ParentId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.Products", new[] { "ImageId" });
            DropIndex("dbo.OrderProducts", new[] { "Order_Id" });
            DropIndex("dbo.OrderProducts", new[] { "Product_Id" });
            DropIndex("dbo.Orders", new[] { "UserEmailMessage_Id" });
            DropIndex("dbo.OrderGames", new[] { "Game_Id" });
            DropIndex("dbo.OrderGames", new[] { "Order_Id" });
            DropIndex("dbo.Games", new[] { "ParrentId" });
            DropIndex("dbo.PageDescriptionImages", new[] { "PageDescription_Id" });
            DropIndex("dbo.PageDescriptionImages", new[] { "Image_Id" });
            RenameColumn(table: "dbo.Products", name: "ImageId", newName: "Image_Id");
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        FatherName = c.String(),
                        Position = c.String(),
                        Slogan = c.String(),
                        OrderNum = c.Int(nullable: false),
                        Description = c.String(),
                        Deleted = c.Boolean(nullable: false),
                        Image_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Images", t => t.Image_Id)
                .Index(t => t.Image_Id);
            
            AddColumn("dbo.Comments", "Company", c => c.String());
            AlterColumn("dbo.Products", "Image_Id", c => c.Int());
            CreateIndex("dbo.Products", "Image_Id");
            AddForeignKey("dbo.Products", "Image_Id", "dbo.Images", "Id");
            DropColumn("dbo.Products", "CategoryId");
            DropColumn("dbo.Products", "Price");
            DropColumn("dbo.Products", "ShortDescription");
            DropColumn("dbo.Products", "IsHot");
            DropColumn("dbo.Images", "Description");
            DropColumn("dbo.UserEmailMessages", "Type");
            DropTable("dbo.Categories");
            DropTable("dbo.PageDescriptions");
            DropTable("dbo.OrderProducts");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderGames");
            DropTable("dbo.Games");
            DropTable("dbo.PageDescriptionImages");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PageDescriptionImages",
                c => new
                    {
                        PageDescription_Id = c.Int(nullable: false),
                        Image_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PageDescription_Id, t.Image_Id });
            
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                        Description = c.String(),
                        ShortDescription = c.String(),
                        DayOfWeek = c.Int(nullable: false),
                        ParrentId = c.Int(),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderGames",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        Game_Id = c.Int(),
                        Order_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        UserEmailMessage_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        Order_Id = c.Int(),
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PageDescriptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        VideoURL = c.String(),
                        ControllerName = c.String(),
                        ActionName = c.String(),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParentId = c.Int(),
                        RussianName = c.String(),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.UserEmailMessages", "Type", c => c.String());
            AddColumn("dbo.Images", "Description", c => c.String());
            AddColumn("dbo.Products", "IsHot", c => c.Boolean(nullable: false));
            AddColumn("dbo.Products", "ShortDescription", c => c.String());
            AddColumn("dbo.Products", "Price", c => c.Double(nullable: false));
            AddColumn("dbo.Products", "CategoryId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Products", "Image_Id", "dbo.Images");
            DropForeignKey("dbo.Doctors", "Image_Id", "dbo.Images");
            DropIndex("dbo.Products", new[] { "Image_Id" });
            DropIndex("dbo.Doctors", new[] { "Image_Id" });
            AlterColumn("dbo.Products", "Image_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Comments", "Company");
            DropTable("dbo.Doctors");
            RenameColumn(table: "dbo.Products", name: "Image_Id", newName: "ImageId");
            CreateIndex("dbo.PageDescriptionImages", "Image_Id");
            CreateIndex("dbo.PageDescriptionImages", "PageDescription_Id");
            CreateIndex("dbo.Games", "ParrentId");
            CreateIndex("dbo.OrderGames", "Order_Id");
            CreateIndex("dbo.OrderGames", "Game_Id");
            CreateIndex("dbo.Orders", "UserEmailMessage_Id");
            CreateIndex("dbo.OrderProducts", "Product_Id");
            CreateIndex("dbo.OrderProducts", "Order_Id");
            CreateIndex("dbo.Products", "ImageId");
            CreateIndex("dbo.Products", "CategoryId");
            CreateIndex("dbo.Categories", "ParentId");
            AddForeignKey("dbo.Products", "ImageId", "dbo.Images", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OrderProducts", "Product_Id", "dbo.Products", "Id");
            AddForeignKey("dbo.Orders", "UserEmailMessage_Id", "dbo.UserEmailMessages", "Id");
            AddForeignKey("dbo.OrderProducts", "Order_Id", "dbo.Orders", "Id");
            AddForeignKey("dbo.OrderGames", "Order_Id", "dbo.Orders", "Id");
            AddForeignKey("dbo.Games", "ParrentId", "dbo.Games", "Id");
            AddForeignKey("dbo.OrderGames", "Game_Id", "dbo.Games", "Id");
            AddForeignKey("dbo.PageDescriptionImages", "Image_Id", "dbo.Images", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PageDescriptionImages", "PageDescription_Id", "dbo.PageDescriptions", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Products", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Categories", "ParentId", "dbo.Categories", "Id");
        }
    }
}
