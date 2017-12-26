using Glabsiennsoft.Contracts.Common.MIgrations;

namespace Glabsiennsoft.MIgrate.Migrations
{
    [Migration("Added categories")]
    public class M2 : Migration
    {
        public override void Up()
        {
            Sql(@"create table categories
                (
	                code uniqueidentifier not null primary key,
	                description nvarchar(max) not null
                )");
        }

        public override void Down()
        {
            Sql("drop table categories");
        }
    }
}