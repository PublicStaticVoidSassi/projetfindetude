using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Repositories;

namespace UniFlowCRM.Contacts
{
    public interface IContactsRepository: IRepository<Contact>
    {
    }
}
