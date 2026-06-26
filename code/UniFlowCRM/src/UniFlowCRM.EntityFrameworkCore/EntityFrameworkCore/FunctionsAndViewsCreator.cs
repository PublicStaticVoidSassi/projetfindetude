using Microsoft.EntityFrameworkCore.Migrations;
namespace UniFlowCRM.Migrations;

public static class FunctionsAndViewsCreator
{
    public static void CreateViews(this MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql(@"create or alter view crm.incomepercurrency as
	select
		(SELECT crm.totalincome(0)) as dzdincome,
		(SELECT crm.totalincome(1)) as eurincome,
		(SELECT crm.totalincome(2)) as usdincome");
        migrationBuilder.Sql(@"create or alter view crm.dashboard as
select
	pendingleads = (select count(id) from crm.leads where status != 3 and status != 5),
	convertedleads = (select count(id) from crm.leads where status = 3),
	deadleads = (select count(id) from crm.leads where status = 5),
	activecontacts = (select count(id) from crm.contacts where status=1),
	inactivecontacts = (select count(id) from crm.contacts where status=0),
	totalaccounts = (select count(id) from crm.accounts) ,
	pendingdeals = (select count(id) from crm.Opportunities o where o.Stage != 8 and o.Stage != 9),
	wondeals = (select count(id) from crm.Opportunities o where o.Stage = 8 ),
	lostdeals = (select count(id) from crm.Opportunities o where o.Stage = 9 );");

    }
    public static void CreateFunctions(this MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql(@"CREATE OR ALTER FUNCTION crm.TotalIncome (@currency INT) RETURNS DECIMAL(18,2)
AS BEGIN
	DECLARE @total DECIMAL(18,2);
	SELECT @total = ISNULL(SUM(o.AmountValue), 0)
	FROM crm.Opportunities o
	WHERE stage=8 AND o.AmountCurrency = @currency;
RETURN @total;
END;"
        );
    }
}
