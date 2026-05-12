using UniFlowCRM.Accounts;
using Volo.Abp.Identity;

namespace UniFlowCRM.Leads;
// nice idea but not really worth it for my case
public class LeadAccountUser
{
    public Lead lead { get; set; }
    public Account? ParentAccount { get; set; }
    public IdentityUser AssignedTo { get; set; }
}
