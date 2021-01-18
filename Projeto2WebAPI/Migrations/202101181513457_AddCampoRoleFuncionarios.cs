namespace Projeto2WebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCampoRoleFuncionarios : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FuncionariosSistemas", "Role", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.FuncionariosSistemas", "Role");
        }
    }
}
