using System;
using System.Collections.Generic;
using System.Text;
using UniFlowCRM.Books;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace UniFlowCRM.Contacts
{
    public interface IContactsAppService : ICrudAppService<ContactDto,Guid,PagedAndSortedResultRequestDto,CreateUpdateContactDto>
    {
    }
}
