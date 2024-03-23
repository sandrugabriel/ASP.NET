using FluentMigrator;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ApartamentAPI.Data.Migrations
{

    [Migration(03032024)]
    public class CreateSchema : Migration
    {
        public override void Up()
        {
            Create.Table("apartaments")
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("numberRooms").AsInt32().NotNullable()
                .WithColumn("address").AsString().Nullable()
                .WithColumn("price").AsInt32().NotNullable();
        }

        public override void Down() { }
    }
}
