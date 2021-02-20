namespace Control.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedTime = c.DateTime(nullable: false),
                        DeletedTime = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        IsConfirm = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        ShippedDate = c.DateTime(nullable: false),
                        RequiredDate = c.DateTime(nullable: false),
                        Freight = c.Double(nullable: false),
                        ShipAddress = c.String(),
                        ShipPostalCode = c.String(),
                        CountryId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        ProvinceId = c.Int(nullable: false),
                        RegionId = c.Int(nullable: false),
                        CityId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        ShipperId = c.Int(nullable: false),
                        NoteId = c.Int(),
                        CreatedTime = c.DateTime(nullable: false),
                        DeletedTime = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        IsConfirm = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Notes", t => t.NoteId)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .ForeignKey("dbo.Provinces", t => t.ProvinceId, cascadeDelete: true)
                .ForeignKey("dbo.Regions", t => t.RegionId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .ForeignKey("dbo.Shippers", t => t.ShipperId, cascadeDelete: true)
                .Index(t => t.CountryId)
                .Index(t => t.CategoryId)
                .Index(t => t.ProvinceId)
                .Index(t => t.RegionId)
                .Index(t => t.CityId)
                .Index(t => t.CustomerId)
                .Index(t => t.ShipperId)
                .Index(t => t.NoteId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ProvinceId = c.Int(),
                        CreatedTime = c.DateTime(nullable: false),
                        DeletedTime = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        IsConfirm = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Provinces", t => t.ProvinceId)
                .Index(t => t.ProvinceId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameSurname = c.String(),
                        CompanyName = c.String(),
                        Title = c.String(),
                        PaymentId = c.Int(nullable: false),
                        CountryId = c.Int(),
                        RegionId = c.Int(),
                        ProductId = c.Int(nullable: false),
                        ProvinceId = c.Int(),
                        CityId = c.Int(),
                        CustomerInfoId = c.Int(nullable: false),
                        NoteId = c.Int(),
                        CreatedTime = c.DateTime(nullable: false),
                        DeletedTime = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        IsConfirm = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId)
                .ForeignKey("dbo.Countries", t => t.CountryId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Notes", t => t.NoteId)
                .ForeignKey("dbo.Payments", t => t.PaymentId, cascadeDelete: true)
                .ForeignKey("dbo.Provinces", t => t.ProvinceId)
                .ForeignKey("dbo.Regions", t => t.RegionId)
                .ForeignKey("dbo.CustomerInfoes", t => t.CustomerInfoId, cascadeDelete: true)
                .Index(t => t.PaymentId)
                .Index(t => t.CountryId)
                .Index(t => t.RegionId)
                .Index(t => t.ProductId)
                .Index(t => t.ProvinceId)
                .Index(t => t.CityId)
                .Index(t => t.CustomerInfoId)
                .Index(t => t.NoteId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedTime = c.DateTime(nullable: false),
                        DeletedTime = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        IsConfirm = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FromWheres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        CountryId = c.Int(nullable: false),
                        CreatedTime = c.DateTime(nullable: false),
                        DeletedTime = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        IsConfirm = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductNumber = c.String(),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InStock = c.Boolean(nullable: false),
                        Stock = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        CategoryId = c.Int(),
                        FromWhereId = c.Int(),
                        ToWhereId = c.Int(),
                        SubcategoryId = c.Int(),
                        NoteId = c.Int(),
                        CreatedTime = c.DateTime(nullable: false),
                        DeletedTime = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        IsConfirm = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .ForeignKey("dbo.FromWheres", t => t.FromWhereId)
                .ForeignKey("dbo.Notes", t => t.NoteId)
                .ForeignKey("dbo.Subcategories", t => t.SubcategoryId)
                .ForeignKey("dbo.ToWheres", t => t.ToWhereId)
                .Index(t => t.CategoryId)
                .Index(t => t.FromWhereId)
                .Index(t => t.ToWhereId)
                .Index(t => t.SubcategoryId)
                .Index(t => t.NoteId);
            
            CreateTable(
                "dbo.Notes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        CreatedTime = c.DateTime(nullable: false),
                        DeletedTime = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        IsConfirm = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameSurname = c.String(),
                        Gender = c.Boolean(),
                        Birthdate = c.DateTime(nullable: false),
                        HireDate = c.DateTime(nullable: false),
                        TitleId = c.Int(nullable: false),
                        EmployeeInfoId = c.Int(nullable: false),
                        NoteId = c.Int(),
                        CreatedTime = c.DateTime(nullable: false),
                        DeletedTime = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        IsConfirm = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EmployeeInfoes", t => t.EmployeeInfoId, cascadeDelete: true)
                .ForeignKey("dbo.Notes", t => t.NoteId)
                .ForeignKey("dbo.Titles", t => t.TitleId, cascadeDelete: true)
                .Index(t => t.TitleId)
                .Index(t => t.EmployeeInfoId)
                .Index(t => t.NoteId);
            
            CreateTable(
                "dbo.EmployeeInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        Country = c.String(),
                        Province = c.String(),
                        City = c.String(),
                        PhoneNumber = c.String(),
                        HomeNumber = c.String(),
                        Photo = c.String(),
                        CreatedTime = c.DateTime(nullable: false),
                        DeletedTime = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        IsConfirm = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Titles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedTime = c.DateTime(nullable: false),
                        DeletedTime = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        IsConfirm = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        NoteId = c.Int(),
                        CreatedTime = c.DateTime(nullable: false),
                        DeletedTime = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        IsConfirm = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Notes", t => t.NoteId)
                .Index(t => t.NoteId);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        Discount = c.Double(nullable: false),
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(),
                        CreatedTime = c.DateTime(nullable: false),
                        DeletedTime = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        IsConfirm = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Subcategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CateoryId = c.Int(),
                        CreatedTime = c.DateTime(nullable: false),
                        DeletedTime = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        IsConfirm = c.Boolean(nullable: false),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.ToWheres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        CountryId = c.Int(),
                        CreatedTime = c.DateTime(nullable: false),
                        DeletedTime = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        IsConfirm = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Provinces",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CountryId = c.Int(),
                        RegionId = c.Int(),
                        CreatedTime = c.DateTime(nullable: false),
                        DeletedTime = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        IsConfirm = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId)
                .ForeignKey("dbo.Regions", t => t.RegionId)
                .Index(t => t.CountryId)
                .Index(t => t.RegionId);
            
            CreateTable(
                "dbo.Regions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedTime = c.DateTime(nullable: false),
                        DeletedTime = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        IsConfirm = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CustomerInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        PostalCode = c.String(),
                        PhoneNumber = c.String(),
                        MailAddress = c.String(),
                        Fax = c.String(),
                        WebSite = c.String(),
                        CreatedTime = c.DateTime(nullable: false),
                        DeletedTime = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        IsConfirm = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Shippers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                        CreatedTime = c.DateTime(nullable: false),
                        DeletedTime = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        IsConfirm = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Communicates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameSurname = c.String(nullable: false),
                        Subject = c.String(nullable: false),
                        Text = c.String(nullable: false),
                        CreatedTime = c.DateTime(nullable: false),
                        DeletedTime = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        IsConfirm = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Description = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        NameLastname = c.String(),
                        Country = c.String(),
                        City = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Orders", "ShipperId", "dbo.Shippers");
            DropForeignKey("dbo.Orders", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Customers", "CustomerInfoId", "dbo.CustomerInfoes");
            DropForeignKey("dbo.Provinces", "RegionId", "dbo.Regions");
            DropForeignKey("dbo.Orders", "RegionId", "dbo.Regions");
            DropForeignKey("dbo.Customers", "RegionId", "dbo.Regions");
            DropForeignKey("dbo.Orders", "ProvinceId", "dbo.Provinces");
            DropForeignKey("dbo.Customers", "ProvinceId", "dbo.Provinces");
            DropForeignKey("dbo.Provinces", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Cities", "ProvinceId", "dbo.Provinces");
            DropForeignKey("dbo.Orders", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Products", "ToWhereId", "dbo.ToWheres");
            DropForeignKey("dbo.ToWheres", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Products", "SubcategoryId", "dbo.Subcategories");
            DropForeignKey("dbo.Subcategories", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.OrderDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Products", "NoteId", "dbo.Notes");
            DropForeignKey("dbo.Payments", "NoteId", "dbo.Notes");
            DropForeignKey("dbo.Customers", "PaymentId", "dbo.Payments");
            DropForeignKey("dbo.Orders", "NoteId", "dbo.Notes");
            DropForeignKey("dbo.Employees", "TitleId", "dbo.Titles");
            DropForeignKey("dbo.Employees", "NoteId", "dbo.Notes");
            DropForeignKey("dbo.Employees", "EmployeeInfoId", "dbo.EmployeeInfoes");
            DropForeignKey("dbo.Customers", "NoteId", "dbo.Notes");
            DropForeignKey("dbo.Products", "FromWhereId", "dbo.FromWheres");
            DropForeignKey("dbo.Customers", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.FromWheres", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Customers", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Customers", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Orders", "CategoryId", "dbo.Categories");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Provinces", new[] { "RegionId" });
            DropIndex("dbo.Provinces", new[] { "CountryId" });
            DropIndex("dbo.ToWheres", new[] { "CountryId" });
            DropIndex("dbo.Subcategories", new[] { "Category_Id" });
            DropIndex("dbo.OrderDetails", new[] { "ProductId" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropIndex("dbo.Payments", new[] { "NoteId" });
            DropIndex("dbo.Employees", new[] { "NoteId" });
            DropIndex("dbo.Employees", new[] { "EmployeeInfoId" });
            DropIndex("dbo.Employees", new[] { "TitleId" });
            DropIndex("dbo.Products", new[] { "NoteId" });
            DropIndex("dbo.Products", new[] { "SubcategoryId" });
            DropIndex("dbo.Products", new[] { "ToWhereId" });
            DropIndex("dbo.Products", new[] { "FromWhereId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.FromWheres", new[] { "CountryId" });
            DropIndex("dbo.Customers", new[] { "NoteId" });
            DropIndex("dbo.Customers", new[] { "CustomerInfoId" });
            DropIndex("dbo.Customers", new[] { "CityId" });
            DropIndex("dbo.Customers", new[] { "ProvinceId" });
            DropIndex("dbo.Customers", new[] { "ProductId" });
            DropIndex("dbo.Customers", new[] { "RegionId" });
            DropIndex("dbo.Customers", new[] { "CountryId" });
            DropIndex("dbo.Customers", new[] { "PaymentId" });
            DropIndex("dbo.Cities", new[] { "ProvinceId" });
            DropIndex("dbo.Orders", new[] { "NoteId" });
            DropIndex("dbo.Orders", new[] { "ShipperId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropIndex("dbo.Orders", new[] { "CityId" });
            DropIndex("dbo.Orders", new[] { "RegionId" });
            DropIndex("dbo.Orders", new[] { "ProvinceId" });
            DropIndex("dbo.Orders", new[] { "CategoryId" });
            DropIndex("dbo.Orders", new[] { "CountryId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Communicates");
            DropTable("dbo.Shippers");
            DropTable("dbo.CustomerInfoes");
            DropTable("dbo.Regions");
            DropTable("dbo.Provinces");
            DropTable("dbo.ToWheres");
            DropTable("dbo.Subcategories");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Payments");
            DropTable("dbo.Titles");
            DropTable("dbo.EmployeeInfoes");
            DropTable("dbo.Employees");
            DropTable("dbo.Notes");
            DropTable("dbo.Products");
            DropTable("dbo.FromWheres");
            DropTable("dbo.Countries");
            DropTable("dbo.Customers");
            DropTable("dbo.Cities");
            DropTable("dbo.Orders");
            DropTable("dbo.Categories");
        }
    }
}
