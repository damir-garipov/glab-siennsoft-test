using System;
using System.Collections.Generic;
using System.Text;
using Glabsiennsoft.Contracts.Common.MIgrations;

namespace Glabsiennsoft.MIgrate.Migrations
{
    [Migration("Added units")]
    public class M1: Migration
    {
        public override void Up()
        {
            Sql(@"create table units
                (
	                code uniqueidentifier not null primary key,
	                description nvarchar(max) not null
                )");
        }

        public override void Down()
        {
            Sql("drop table units");
        }
    }
}
