namespace PPP_Salaire.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingSomeSalaireGenericAttributs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Salaires", "Heures_supplementaires", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Cotisations", "Cotisations_chômage", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Cotisations", "Cotisations_retraite_complémentaire_ARRCO", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Cotisations", "Cotisations_retraite_complémentaire_AGIRC", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Cotisations", "Cotisations_prévoyance", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Cotisations", "Cotisations_mutuelle", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Cotisations", "Cotisations_retraite_supplémentaire", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Cotisations", "Cotisation_CSG_non_déductible", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Cotisations", "Acomptes_sur_salaire", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Cotisations", "Titres_restaurant", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Remunerations", "Avantages_en_nature_éventuels", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Remunerations", "Remboursement_de_frais", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Remunerations", "prime_ancienneté", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Remunerations", "prime_de_productivité", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Salaires", "Heures_supplementaire");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Salaires", "Heures_supplementaire", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Remunerations", "prime_de_productivité");
            DropColumn("dbo.Remunerations", "prime_ancienneté");
            DropColumn("dbo.Remunerations", "Remboursement_de_frais");
            DropColumn("dbo.Remunerations", "Avantages_en_nature_éventuels");
            DropColumn("dbo.Cotisations", "Titres_restaurant");
            DropColumn("dbo.Cotisations", "Acomptes_sur_salaire");
            DropColumn("dbo.Cotisations", "Cotisation_CSG_non_déductible");
            DropColumn("dbo.Cotisations", "Cotisations_retraite_supplémentaire");
            DropColumn("dbo.Cotisations", "Cotisations_mutuelle");
            DropColumn("dbo.Cotisations", "Cotisations_prévoyance");
            DropColumn("dbo.Cotisations", "Cotisations_retraite_complémentaire_AGIRC");
            DropColumn("dbo.Cotisations", "Cotisations_retraite_complémentaire_ARRCO");
            DropColumn("dbo.Cotisations", "Cotisations_chômage");
            DropColumn("dbo.Salaires", "Heures_supplementaires");
        }
    }
}
