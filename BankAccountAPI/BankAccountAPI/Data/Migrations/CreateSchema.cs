using FluentMigrator;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BankAccountAPI.Data.Migrations
{

    [Migration(03032024)]
    public class CreateSchema : Migration
    {
        public override void Up()
        {
            Create.Table("bank")
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("balance").AsInt32().NotNullable()
                .WithColumn("type").AsString().Nullable()
                .WithColumn("ownerName").AsString().NotNullable();
        }

        public override void Down() { }
    }
}
