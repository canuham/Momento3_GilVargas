namespace ApiTatuajes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModeloInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artistas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Especialidad = c.String(),
                        Telefono = c.String(),
                        Imagen = c.String(),
                        Estudio_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Estudios", t => t.Estudio_Id)
                .Index(t => t.Estudio_Id);
            
            CreateTable(
                "dbo.Estudios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        Direccion = c.String(),
                        Whatsapp = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Usuario = c.String(),
                        Clave = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Artistas", "Estudio_Id", "dbo.Estudios");
            DropIndex("dbo.Artistas", new[] { "Estudio_Id" });
            DropTable("dbo.Logins");
            DropTable("dbo.Estudios");
            DropTable("dbo.Artistas");
        }
    }
}
