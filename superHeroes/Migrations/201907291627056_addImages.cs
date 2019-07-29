namespace superHeroes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addImages : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SuperHeroes", "imgPath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SuperHeroes", "imgPath");
        }
    }
}
