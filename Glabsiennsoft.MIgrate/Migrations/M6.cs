using Glabsiennsoft.Contracts.Common.MIgrations;

namespace Glabsiennsoft.MIgrate.Migrations
{
    [Migration("Add product index by codeProduct")]
    public class M6: Migration
    {
        public override void Up()
        {
            Sql(@"create index IX_products_codeType on products (codeType)
                  create index IX_products_codeUnit on products (codeUnit)");
        }

        public override void Down()
        {
            Sql(@"drop index IX_products_codeType on products
                  drop index IX_products_codeUnit on products");
        }
    }
}