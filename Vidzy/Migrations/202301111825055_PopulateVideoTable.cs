namespace Vidzy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateVideoTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Videos (Title) VALUES ('Spider Man')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Videos WHERE Title='Spider Man'");
        }
    }
}
