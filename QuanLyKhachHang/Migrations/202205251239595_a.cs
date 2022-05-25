namespace QuanLyKhachHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HopDongs", "createdAt", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.HopDongs", "createdAt");
        }
    }
}
