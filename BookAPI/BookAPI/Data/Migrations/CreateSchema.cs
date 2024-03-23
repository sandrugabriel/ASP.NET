using FluentMigrator;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BookAPI.Data.Migrations
{
    [Migration(03032024)]
    public class CreateSchema : Migration
    {
        public override void Up()
        {
            Create.Table("books")
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("title").AsString().NotNullable()
                .WithColumn("author").AsString().Nullable()
                .WithColumn("year").AsInt32().NotNullable();
        }

        public override void Down() { }
    }
}
