using Glabsiennsoft.Contracts.Common.MIgrations;

namespace Glabsiennsoft.MIgrate.Migrations
{
    [Migration("Added productcategories")]
    public class M5 : Migration
    {
        public override void Up()
        {
            Sql(@"create table productcategories
            (
                codeProduct uniqueidentifier not null,
            codeCategory uniqueidentifier not null,
            constraint PK_productcategories primary key(codeProduct, codeCategory),
            constraint FK_productcategories_categories foreign key(codeCategory) references categories(code) on delete cascade,
                constraint FK_productcategories_products foreign key(codeProduct) references products(code) on delete cascade
            )");
        }

        public override void Down()
        {
            Sql("drop table productcategories");
        }
    }
}