using FluentMigrator;

namespace VacationAPI.Data.Migrations
{
    [Migration(21032024)]
    public class Test : Migration
    {
        public override void Up()
        {
            Execute.Script(@"./Data/Scripts/data.sql");
        }

        public override void Down()
        {

        }

    }
}
