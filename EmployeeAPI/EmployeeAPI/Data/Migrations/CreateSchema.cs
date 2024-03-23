using FluentMigrator;
using Microsoft.AspNetCore.Http.HttpResults;

namespace EmployeeAPI.Data.Migrations
{

    [Migration(03032024)]
    public class CreateSchema : Migration
    {
        public override void Up()
        {
            Create.Table("employees")
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("name").AsString().NotNullable()
                .WithColumn("departament").AsString().Nullable()
                .WithColumn("salary").AsInt32().NotNullable();
        }

        public override void Down() { }
    }
}
