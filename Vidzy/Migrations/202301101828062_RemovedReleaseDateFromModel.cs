namespace Vidzy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedReleaseDateFromModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Videos", "ReleaseDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Videos", "ReleaseDate", c => c.DateTime(nullable: false));
        }
    }
}
