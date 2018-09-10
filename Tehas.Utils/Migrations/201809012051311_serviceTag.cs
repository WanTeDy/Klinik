namespace Klinik.Utils.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class serviceTag : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Tag", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Tag");
        }
    }
}
