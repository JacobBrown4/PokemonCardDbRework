namespace PokemonCard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tryingafix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Card", "Set_SetId", "dbo.PokemonSet");
            DropIndex("dbo.Card", new[] { "Set_SetId" });
            RenameColumn(table: "dbo.Card", name: "Set_SetId", newName: "SetId");
            AlterColumn("dbo.Card", "SetId", c => c.Int(nullable: true));
            CreateIndex("dbo.Card", "SetId");
            AddForeignKey("dbo.Card", "SetId", "dbo.PokemonSet", "SetId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Card", "SetId", "dbo.PokemonSet");
            DropIndex("dbo.Card", new[] { "SetId" });
            AlterColumn("dbo.Card", "SetId", c => c.Int());
            RenameColumn(table: "dbo.Card", name: "SetId", newName: "Set_SetId");
            CreateIndex("dbo.Card", "Set_SetId");
            AddForeignKey("dbo.Card", "Set_SetId", "dbo.PokemonSet", "SetId");
        }
    }
}
