namespace Kosmos.LogServer.DbContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 32),
                        Message = c.String(),
                        Address = c.String(),
                        CreateDate = c.DateTime(),
                        Identity = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Logs");
        }
    }
}
