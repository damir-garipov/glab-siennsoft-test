using Glabsiennsoft.Contracts.Common.MIgrations;

namespace Glabsiennsoft.MIgrate.Migrations
{
    [Migration("Added types")]
    public class M3 : Migration
    {
        public override void Up()
        {
            Sql(@"create table types
                (
	                code uniqueidentifier not null primary key,
	                description nvarchar(max) not null
                )");
        }

        public override void Down()
        {
            Sql("drop table types");
        }
    }
}