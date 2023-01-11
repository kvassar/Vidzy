namespace Vidzy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedManyToManyRelationshipBetweenVideoAndGenre : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VideoGenres", "Video_ID", "dbo.Videos");
            DropForeignKey("dbo.VideoGenres", "Genre_ID", "dbo.Genres");
            DropIndex("dbo.VideoGenres", new[] { "Video_ID" });
            DropIndex("dbo.VideoGenres", new[] { "Genre_ID" });
            AddColumn("dbo.Videos", "Genre_ID", c => c.Byte());
            CreateIndex("dbo.Videos", "Genre_ID");
            AddForeignKey("dbo.Videos", "Genre_ID", "dbo.Genres", "ID");
            DropTable("dbo.VideoGenres");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.VideoGenres",
                c => new
                    {
                        Video_ID = c.Int(nullable: false),
                        Genre_ID = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => new { t.Video_ID, t.Genre_ID });
            
            DropForeignKey("dbo.Videos", "Genre_ID", "dbo.Genres");
            DropIndex("dbo.Videos", new[] { "Genre_ID" });
            DropColumn("dbo.Videos", "Genre_ID");
            CreateIndex("dbo.VideoGenres", "Genre_ID");
            CreateIndex("dbo.VideoGenres", "Video_ID");
            AddForeignKey("dbo.VideoGenres", "Genre_ID", "dbo.Genres", "ID", cascadeDelete: true);
            AddForeignKey("dbo.VideoGenres", "Video_ID", "dbo.Videos", "ID", cascadeDelete: true);
        }
    }
}
