namespace PPP_Salaire.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestMerging : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Conges", "NbJours", c => c.Int(nullable: false));
            AddColumn("dbo.Conges", "Par_Jours_De_Travail", c => c.Int(nullable: false));
            AddColumn("dbo.Conges", "Justifié", c => c.Int(nullable: false));
            AlterColumn("dbo.Salaires", "Heures_travaillées", c => c.Int(nullable: false));
            AlterColumn("dbo.Salaires", "Heures_retards", c => c.Int(nullable: false));
            AlterColumn("dbo.Salaires", "Heures_supplementaire", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Salaires", "Heures_supplementaire", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Salaires", "Heures_retards", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Salaires", "Heures_travaillées", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Conges", "Justifié");
            DropColumn("dbo.Conges", "Par_Jours_De_Travail");
            DropColumn("dbo.Conges", "NbJours");
        }
    }
}
