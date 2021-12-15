namespace PokemonCard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedsomestuff : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Card", "ItemAbility", c => c.String());
            AddColumn("dbo.Card", "PokemonType", c => c.Int());
            AddColumn("dbo.Card", "Evolves", c => c.Boolean());
            AddColumn("dbo.Card", "Attack1", c => c.String());
            AddColumn("dbo.Card", "Attack2", c => c.String());
            AddColumn("dbo.Card", "StadiumAbility", c => c.String());
            AddColumn("dbo.Card", "SupporterAbility", c => c.String());
            AddColumn("dbo.Card", "ToolAbility", c => c.String());
            AddColumn("dbo.Card", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Card", "Discriminator");
            DropColumn("dbo.Card", "ToolAbility");
            DropColumn("dbo.Card", "SupporterAbility");
            DropColumn("dbo.Card", "StadiumAbility");
            DropColumn("dbo.Card", "Attack2");
            DropColumn("dbo.Card", "Attack1");
            DropColumn("dbo.Card", "Evolves");
            DropColumn("dbo.Card", "PokemonType");
            DropColumn("dbo.Card", "ItemAbility");
        }
    }
}
