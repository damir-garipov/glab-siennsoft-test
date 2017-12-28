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

    [Migration("Add Price column to products")]
    public class M7 : Migration
    {
        public override void Up()
        {
            Sql("alter table products add price money");
        }

        public override void Down()
        {
            Sql("alter table products drop column price");
        }
    }

    [Migration("Add view UnabailableProductsInLastMonth")]
    public class M8 : Migration
    {
        public override void Up()
        {
            Sql(@"create view UnabailableProductsInLastMonth
                as
                select* from products where isAvailable = 0 and deliveryDate between DATEADD(M, -1, deliveryDate) and deliveryDate");
        }

        public override void Down()
        {
            Sql("drop view UnabailableProductsInLastMonth");
        }
    }
}