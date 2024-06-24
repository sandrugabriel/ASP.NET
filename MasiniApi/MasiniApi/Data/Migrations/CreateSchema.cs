using FluentMigrator;

namespace MasiniApi.Data.Migrations
{
    [Migration(03032024)]
    public class CreateSchema : Migration
    {

        public override void Up()
        {
            Create.Table("Cars")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("UserId").AsInt32().NotNullable()
                .WithColumn("Brand").AsString().Nullable()
                .WithColumn("Model").AsString().NotNullable()
                .WithColumn("Year").AsInt32().NotNullable()
                .WithColumn("Color").AsString().NotNullable();

            Create.Table("Users")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("UserName").AsString(256).Nullable()
            .WithColumn("NormalizedUserName").AsString(256).Nullable()
            .WithColumn("Email").AsString(256).Nullable()
            .WithColumn("NormalizedEmail").AsString(256).Nullable()
            .WithColumn("EmailConfirmed").AsBoolean().NotNullable()
            .WithColumn("PasswordHash").AsString().Nullable()
            .WithColumn("SecurityStamp").AsString().Nullable()
            .WithColumn("ConcurrencyStamp").AsString().Nullable()
            .WithColumn("PhoneNumber").AsString().Nullable()
            .WithColumn("PhoneNumberConfirmed").AsBoolean().NotNullable()
            .WithColumn("TwoFactorEnabled").AsBoolean().NotNullable()
            .WithColumn("LockoutEnd").AsDateTime().Nullable()
            .WithColumn("LockoutEnabled").AsBoolean().NotNullable()
            .WithColumn("AccessFailedCount").AsInt32().NotNullable()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("Age").AsInt32().Nullable()
                .WithColumn("Discriminator").AsString().NotNullable();
            Create.Table("AspNetRoles")
                      .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                      .WithColumn("Name").AsString(256).Nullable()
                      .WithColumn("NormalizedName").AsString(256).Nullable()
                      .WithColumn("ConcurrencyStamp").AsString().Nullable();

            Create.Table("AspNetUserRoles")
                .WithColumn("UserId").AsInt32().NotNullable()
                .WithColumn("RoleId").AsInt32().NotNullable()
                .ForeignKey("FK_AspNetUserRoles_Users", "Users", "Id")
                .ForeignKey("FK_AspNetUserRoles_AspNetRoles", "AspNetRoles", "Id");

            Create.Table("AspNetRoleClaims")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("RoleId").AsInt32().NotNullable()
                .WithColumn("ClaimType").AsString(255).Nullable()
                .WithColumn("ClaimValue").AsInt32().Nullable()
                .ForeignKey("FK_AspNetRoleClaims_AspNetRoles", "AspNetRoles", "Id");


            Create.Table("AspNetUserClaims")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("UserId").AsInt32().NotNullable()
                .WithColumn("ClaimType").AsString().Nullable()
                .WithColumn("ClaimValue").AsInt32().Nullable()
                .ForeignKey("FK_AspNetUserClaims_Users", "Users", "Id");

            Create.Table("AspNetUserLogins")
                .WithColumn("LoginProvider").AsString(256).PrimaryKey()
                .WithColumn("ProviderKey").AsString(256).PrimaryKey()
                .WithColumn("ProviderDisplayName").AsString().Nullable()
                .WithColumn("UserId").AsInt32().NotNullable()
                .ForeignKey("FK_AspNetUserLogins_Users", "Users", "Id");

            Create.Table("AspNetUserTokens")
                .WithColumn("UserId").AsInt32().PrimaryKey()
                .WithColumn("LoginProvider").AsString(256).PrimaryKey()
                .WithColumn("Name").AsString(256).PrimaryKey()
                .WithColumn("Value").AsInt32().Nullable()
                .ForeignKey("FK_AspNetUserTokens_Users", "Users", "Id");

            AddRoles();
            AddPermissionsToRole();
        }

        public override void Down()
        {

        }


        private void AddRoles()
        {
            Insert.IntoTable("AspNetRoles").Row(new {Name = "Admin" , NormalizedName = "ADMIN" });
            Insert.IntoTable("AspNetRoles").Row(new {Name = "Editor", NormalizedName = "EDITOR" });

        }

        private void AddPermissionsToRole()
        {
            Insert.IntoTable("AspNetRoleClaims").Row(new { RoleId = 1 , ClaimType = "Permission" , ClaimValue = 1 });
            Insert.IntoTable("AspNetRoleClaims").Row(new { RoleId = 2, ClaimType = "Permission", ClaimValue = 1 });

        }



    }
}
