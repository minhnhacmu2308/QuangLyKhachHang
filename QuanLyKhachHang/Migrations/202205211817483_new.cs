namespace QuanLyKhachHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DaiLies",
                c => new
                    {
                        idDaiLy = c.Int(nullable: false, identity: true),
                        chuDaiLy = c.String(maxLength: 255),
                        tenDaiLy = c.String(maxLength: 255),
                        diaChi = c.String(),
                        nganhBuonBan = c.String(),
                    })
                .PrimaryKey(t => t.idDaiLy);
            
            CreateTable(
                "dbo.HopDongs",
                c => new
                    {
                        idHopDong = c.Int(nullable: false, identity: true),
                        ngayKy = c.String(maxLength: 255),
                        thoiHan = c.String(maxLength: 255),
                        tongTien = c.Int(nullable: false),
                        idNguoiDung = c.Int(nullable: false),
                        idDaiLy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idHopDong)
                .ForeignKey("dbo.DaiLies", t => t.idDaiLy)
                .ForeignKey("dbo.NguoiDungs", t => t.idNguoiDung)
                .Index(t => t.idNguoiDung)
                .Index(t => t.idDaiLy);
            
            CreateTable(
                "dbo.NguoiDungs",
                c => new
                    {
                        idNguoiDung = c.Int(nullable: false, identity: true),
                        hoTen = c.String(maxLength: 255),
                        soDienThoai = c.String(maxLength: 255),
                        gioiTinh = c.String(),
                        diaChi = c.String(maxLength: 255),
                        email = c.String(maxLength: 255),
                        ngheNghiep = c.String(maxLength: 255),
                        loaiKhachHang = c.String(),
                        role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idNguoiDung);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HopDongs", "idNguoiDung", "dbo.NguoiDungs");
            DropForeignKey("dbo.HopDongs", "idDaiLy", "dbo.DaiLies");
            DropIndex("dbo.HopDongs", new[] { "idDaiLy" });
            DropIndex("dbo.HopDongs", new[] { "idNguoiDung" });
            DropTable("dbo.NguoiDungs");
            DropTable("dbo.HopDongs");
            DropTable("dbo.DaiLies");
        }
    }
}
