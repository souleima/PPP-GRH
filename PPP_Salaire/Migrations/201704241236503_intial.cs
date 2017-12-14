namespace PPP_Salaire.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Conges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DemandeConges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateDebut = c.String(),
                        DateFin = c.String(),
                        DateSubmit = c.String(),
                        CongeID = c.Int(nullable: false),
                        NbreJours = c.Int(nullable: false),
                        Raison = c.String(),
                        Status = c.String(),
                        Employe_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employes", t => t.Employe_Id)
                .Index(t => t.Employe_Id);
            
            CreateTable(
                "dbo.Employes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        login = c.String(maxLength: 450),
                        password = c.String(),
                        Nom = c.String(),
                        Prenom = c.String(),
                        Adresse = c.String(),
                        NumSS = c.Int(nullable: false),
                        DateEmbauche = c.DateTime(nullable: false),
                        CategorieId_Id = c.Int(),
                        Salaire_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategorieId_Id)
                .ForeignKey("dbo.Salaires", t => t.Salaire_Id)
                .Index(t => t.login, unique: true, name: "login")
                .Index(t => t.CategorieId_Id)
                .Index(t => t.Salaire_Id);
            
            CreateTable(
                "dbo.Salaires",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Salaire_de_base = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Heures_travaillées = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Heures_retards = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Heures_supplementaire = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cotisation_Id = c.Int(),
                        Remuneration_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cotisations", t => t.Cotisation_Id)
                .ForeignKey("dbo.Remunerations", t => t.Remuneration_Id)
                .Index(t => t.Cotisation_Id)
                .Index(t => t.Remuneration_Id);
            
            CreateTable(
                "dbo.Cotisations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cotisations_Urssaf = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cotisations_chômage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cotisations_retraite_complémentaire_ARRCO = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cotisations_retraite_complémentaire_AGIRC = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cotisations_AGFF = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cotisations_APEC = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cotisations_prévoyance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cotisations_mutuelle = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cotisations_retraite_supplémentaire = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cotisation_CSG_déductible = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cotisation_CSG_non_déductible = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cotisation_CRDS = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Acomptes_sur_salaire = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Titres_restaurant = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Remunerations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Remboursement_transports_en_commun = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Primes_éventuelles = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Avantages_en_nature_éventuels = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Remboursement_de_frais = c.Decimal(nullable: false, precision: 18, scale: 2),
                        prime_ancienneté = c.Decimal(nullable: false, precision: 18, scale: 2),
                        prime_de_productivité = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employes", "Salaire_Id", "dbo.Salaires");
            DropForeignKey("dbo.Salaires", "Remuneration_Id", "dbo.Remunerations");
            DropForeignKey("dbo.Salaires", "Cotisation_Id", "dbo.Cotisations");
            DropForeignKey("dbo.DemandeConges", "Employe_Id", "dbo.Employes");
            DropForeignKey("dbo.Employes", "CategorieId_Id", "dbo.Categories");
            DropIndex("dbo.Salaires", new[] { "Remuneration_Id" });
            DropIndex("dbo.Salaires", new[] { "Cotisation_Id" });
            DropIndex("dbo.Employes", new[] { "Salaire_Id" });
            DropIndex("dbo.Employes", new[] { "CategorieId_Id" });
            DropIndex("dbo.Employes", "login");
            DropIndex("dbo.DemandeConges", new[] { "Employe_Id" });
            DropTable("dbo.Remunerations");
            DropTable("dbo.Cotisations");
            DropTable("dbo.Salaires");
            DropTable("dbo.Employes");
            DropTable("dbo.DemandeConges");
            DropTable("dbo.Conges");
            DropTable("dbo.Categories");
        }
    }
}
