using FluentMigrator;
using Microsoft.AspNetCore.Http.HttpResults;

namespace StudentApi.Data.Migrations
{
    [Migration(03032024)]
    public class CreateSchema : Migration
    {
        public override void Up()
        {
            Create.Table("students")
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("name").AsString().NotNullable()
                .WithColumn("age").AsInt32().Nullable()
                .WithColumn("grade").AsInt32().NotNullable();
        }

        public override void Down() { }
    }
}
