using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UniFlowCRM.Contacts;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Volo.Abp.ObjectMapping;

namespace UniFlowCRM.Leads
{
    public class LeadsManager(
        ILeadsRepository Repository,
        IContactsRepository _contactRepository,
        IGuidGenerator GuidGenerator) : ILeadsManager
    {
        // returns the new contact id
        public async Task<Guid> ConvertAsync(Guid id)
        {
            var lead = await Repository.GetAsync(id);
            lead.Convert();
            var contactId = GuidGenerator.Create();
            var contact = new Contact(contactId, lead.FirstName);
            contact.SetLastName(lead.LastName);
            contact.SetEmail(lead.Email);
            contact.AssignUser(lead.UserID);
            contact.AssignLead(lead.Id);
            contact.AssignAccount(lead.AccountID);
            contact.SetSource(ContactSource.ConvertedFromLead);
            contact = await _contactRepository.InsertAsync(contact);
            return contact.Id;
        }
    }
}
