using FluentMigrator;
using Microsoft.AspNetCore.Http.HttpResults;

namespace EventAPI.Data.Migrations
{
    [Migration(03032024)]
    public class CreateSchema : Migration
    {
        public override void Up()
        {
            Create.Table("eventsParty")
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("name").AsString().NotNullable()
                .WithColumn("locationName").AsString().Nullable()
                .WithColumn("date").AsDateTime().NotNullable();
        }

        public override void Down() { }
    }
}
