using FluentMigrator;
using Microsoft.AspNetCore.Http.HttpResults;

namespace VacationAPI.Data.Migrations
{
    [Migration(03032024)]
    public class CreateSchema : Migration
    {
        public override void Up()
        {
            Create.Table("vacations")
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("destination").AsString().NotNullable()
                .WithColumn("duration").AsInt32().Nullable()
                .WithColumn("price").AsInt32().NotNullable();
        }

        public override void Down() { }
    }
}
