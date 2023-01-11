﻿namespace Vidzy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedNameInVideoModelToTitle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Videos", "Title", c => c.String());
            DropColumn("dbo.Videos", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Videos", "Name", c => c.String());
            DropColumn("dbo.Videos", "Title");
        }
    }
}
