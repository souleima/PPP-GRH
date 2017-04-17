namespace PPP_Salaire.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intToDecimalSalaire : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Salaires", "Heures_travaillées", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Salaires", "Heures_retards", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Salaires", "Heures_supplementaire", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Salaires", "Heures_supplementaire", c => c.Int(nullable: false));
            AlterColumn("dbo.Salaires", "Heures_retards", c => c.Int(nullable: false));
            AlterColumn("dbo.Salaires", "Heures_travaillées", c => c.Int(nullable: false));
        }
    }
}
