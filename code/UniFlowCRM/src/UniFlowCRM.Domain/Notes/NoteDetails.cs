using UniFlowCRM.Accounts;
using UniFlowCRM.Contacts;
using UniFlowCRM.Leads;
using UniFlowCRM.Opportunities;

namespace UniFlowCRM.Notes;

public class NoteDetails 
{
    public required Note Note { get; init; }
    public Lead? Lead { get; init; }
    public Contact? Contact { get; init; }
    public Account? Account { get; init; }
    public Opportunity? Opportunity { get; init; }
}