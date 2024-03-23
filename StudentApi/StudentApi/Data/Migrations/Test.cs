using FluentMigrator;

namespace StudentApi.Data.Migrations
{
    [Migration(21032024)]
    public class Test : Migration
    {
        public override void Up()
        {
            Execute.Script(@"./Data/Script/data.sql");
        }

        public override void Down()
        {

        }
    }
}
