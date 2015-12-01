namespace ProyectoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class all : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Compras",
                c => new
                    {
                        idCom = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        newProd = c.String(),
                        cantidades = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idCom);
            
            CreateTable(
                "dbo.Productos",
                c => new
                    {
                        idPro = c.Int(nullable: false, identity: true),
                        NombreProdu = c.String(),
                        Categoria = c.String(),
                        Cantidad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idPro);
            
            CreateTable(
                "dbo.Proveedors",
                c => new
                    {
                        idProv = c.Int(nullable: false, identity: true),
                        NombrePro = c.String(),
                        Ciudad = c.String(),
                        Telefono = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idProv);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Idusu = c.Int(nullable: false, identity: true),
                        NombreUsuario = c.String(),
                        Contraseña = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Idusu);
            
            CreateTable(
                "dbo.Ventas",
                c => new
                    {
                        idventa = c.Int(nullable: false, identity: true),
                        nomfinal = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.idventa);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Ventas");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Proveedors");
            DropTable("dbo.Productos");
            DropTable("dbo.Compras");
        }
    }
}
