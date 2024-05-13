namespace DogHouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InishalMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Breeds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Dogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Age = c.Int(nullable: false),
                        BreedId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Breeds", t => t.BreedId, cascadeDelete: true)
                .Index(t => t.BreedId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dogs", "BreedId", "dbo.Breeds");
            DropIndex("dbo.Dogs", new[] { "BreedId" });
            DropTable("dbo.Dogs");
            DropTable("dbo.Breeds");
        }
    }
}
