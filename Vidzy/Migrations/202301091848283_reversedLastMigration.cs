namespace Vidzy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reversedLastMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Videos", "Genre_ID", "dbo.Genres");
            DropIndex("dbo.Videos", new[] { "Genre_ID" });
            CreateTable(
                "dbo.VideoGenres",
                c => new
                    {
                        Video_ID = c.Int(nullable: false),
                        Genre_ID = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => new { t.Video_ID, t.Genre_ID })
                .ForeignKey("dbo.Videos", t => t.Video_ID, cascadeDelete: true)
                .ForeignKey("dbo.Genres", t => t.Genre_ID, cascadeDelete: true)
                .Index(t => t.Video_ID)
                .Index(t => t.Genre_ID);
            
            DropColumn("dbo.Videos", "Genre_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Videos", "Genre_ID", c => c.Byte());
            DropForeignKey("dbo.VideoGenres", "Genre_ID", "dbo.Genres");
            DropForeignKey("dbo.VideoGenres", "Video_ID", "dbo.Videos");
            DropIndex("dbo.VideoGenres", new[] { "Genre_ID" });
            DropIndex("dbo.VideoGenres", new[] { "Video_ID" });
            DropTable("dbo.VideoGenres");
            CreateIndex("dbo.Videos", "Genre_ID");
            AddForeignKey("dbo.Videos", "Genre_ID", "dbo.Genres", "ID");
        }
    }
}
