
using FluentMigrator;
using Microsoft.AspNetCore.Http.HttpResults;

namespace MovieAPI.Data.Migrations
{
    [Migration(03032024)]
    public class CreateSchema : Migration
    {
        public override void Up()
        {
            Create.Table("movie")
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("title").AsString().NotNullable()
                .WithColumn("releaseYear").AsInt32().Nullable()
                .WithColumn("gender").AsString().NotNullable();
        }

        public override void Down() { }
    }
}
