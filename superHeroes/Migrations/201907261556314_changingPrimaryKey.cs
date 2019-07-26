namespace superHeroes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changingPrimaryKey : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.SuperHeroes");
            AddColumn("dbo.SuperHeroes", "id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.SuperHeroes", "name", c => c.String());
            AddPrimaryKey("dbo.SuperHeroes", "id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.SuperHeroes");
            AlterColumn("dbo.SuperHeroes", "name", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.SuperHeroes", "id");
            AddPrimaryKey("dbo.SuperHeroes", "name");
        }
    }
}
