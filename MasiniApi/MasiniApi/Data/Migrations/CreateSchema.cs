using FluentMigrator;

namespace MasiniApi.Data.Migrations
{
    [Migration(03032024)]
    public class CreateSchema : Migration
    {

        public override void Up()
        {
            Create.Table("masini")
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("marca").AsString().Nullable()
                .WithColumn("model").AsString().NotNullable()
                .WithColumn("anul").AsInt32().NotNullable()
                .WithColumn("culoare").AsString().NotNullable();

        }

        public override void Down()
        {

        }

    }
}
