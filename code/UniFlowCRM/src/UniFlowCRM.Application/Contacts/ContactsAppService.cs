using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using UniFlowCRM.ValueObjects;
namespace UniFlowCRM.Contacts
{
    public class ContactsAppService: CrudAppService<Contact,ContactDto,Guid,PagedAndSortedResultRequestDto,CreateUpdateContactDto>,IContactsAppService
    {
        public ContactsAppService(IRepository<Contact,Guid> repository): base(repository)
        {

        }
        private Contact Initialize(Contact con, CreateUpdateContactDto input)
        {
            con.SetFirstName(input.FirstName);
            con.SetMiddleName(input.MiddleName);
            con.SetLastName(input.LastName);
            con.SetDescription(input.Description);
            con.SetStatus(input.Status);
            con.SetSource(input.Source);
            if (input.PhoneNumber is not null)
                con.SetPhone(new PhoneNumber(number: input.PhoneNumber, countryCode: input.PhoneCode));
            if (input.FaxNumber is not null)
                con.SetFax(new PhoneNumber(number: input.FaxNumber, countryCode: input.FaxCode));
            if (input.Email is not null)
                con.SetEmail(new EmailAddress(input.Email));
            if (input.Website is not null)
                con.SetWebsite(new URL(input.Website));
            con.SetAddress(
                new Address()
                .AddCity(input.City)
                .AddCountry(input.Country)
                .AddStreet(input.Street)
                .AddPostalCode(input.PostalCode)
            );
            con.SetJob(input.Job);
            con.SetDepartment(input.Departement);
            if (input.UserID is not null)
                con.AssignUser((Guid)input.UserID);
            else
                con.AssignUser(CurrentUser.Id!.Value);
            if (input.AccountID is not null)
                con.AssignAccount(input.AccountID);
            if (input.LeadID is not null)
                con.AssignLead(input.LeadID);
            return con;
        }
        public override async Task<ContactDto> CreateAsync(CreateUpdateContactDto input)
        {
            Contact con = new Contact(input.Id, input.FirstName);
            Initialize(con, input);
            await Repository.InsertAsync(con);
            return ObjectMapper.Map<Contact,ContactDto>(con);
        }
        public override async Task<ContactDto> UpdateAsync(Guid id,CreateUpdateContactDto input)
        {
            Contact con = await Repository.FindAsync(id) ?? throw new EntityNotFoundException();
            Initialize(con, input);
            await Repository.UpdateAsync(con);
            return ObjectMapper.Map<Contact, ContactDto>(con);
        }
    }
}
