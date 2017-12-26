using Glabsiennsoft.Contracts.Common.MIgrations;

namespace Glabsiennsoft.MIgrate.Migrations
{
    [Migration("Added products")]
    public class M4: Migration
    {
        public override void Up()
        {
            Sql(@"create table products
                (
	                code uniqueidentifier not null primary key,
	                description nvarchar(max) not null,
	                isAvailable bit not null default 0,
	                deliveryDate datetime2,
	                codeType uniqueidentifier not null,
	                codeUnit uniqueidentifier not null,
	                constraint FK_products_types foreign key (codeType) references types(code),
	                constraint FK_products_units foreign key (codeUnit) references units(code)
                )");
        }

        public override void Down()
        {
            Sql("drop table products");
        }
    }
}