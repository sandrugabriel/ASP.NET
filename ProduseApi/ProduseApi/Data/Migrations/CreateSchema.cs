using FluentMigrator;

namespace ProduseApi.Data.Migrations
{
    [Migration(03032024)]
    public class CreateSchema : Migration
    {
        public override void Up()
        {
            Create.Table("produse")
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("name").AsString().NotNullable()
                .WithColumn("data_expirari").AsDateTime().Nullable()
                .WithColumn("pret").AsInt32().NotNullable();
        }

        public override void Down() { }
    }
}
