namespace PPP_Salaire.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CongeRectifie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Conges", "NbJours", c => c.Int(nullable: false));
            AddColumn("dbo.Conges", "Par_Jours_De_Travail", c => c.Int(nullable: false));
            AddColumn("dbo.Conges", "Justifié", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Conges", "Justifié");
            DropColumn("dbo.Conges", "Par_Jours_De_Travail");
            DropColumn("dbo.Conges", "NbJours");
        }
    }
}
