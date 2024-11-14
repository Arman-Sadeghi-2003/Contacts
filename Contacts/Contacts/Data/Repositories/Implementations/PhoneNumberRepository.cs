using Contacts.Data.DataContext;
using Contacts.Data.Repositories.Interfaces;
using Contacts.Models.Entities.ContactDetails;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Data.Repositories.Implementations
{
    public class PhoneNumberRepository : IPhoneNumberRepository
    {
        private readonly ContactDbContext context;

        public PhoneNumberRepository(ContactDbContext context)
        {
            this.context = context;
        }

        public async Task AddPhoneNumber(PhoneNumber number)
        {
            try
            {
                await context.phoneNumbers.AddAsync(number);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                new MessageBoxView("Error for add new Phone number", ex.Message).Show();
            }
        }

        public async Task DeletePhoneNumber(PhoneNumber number)
        {
            try
            {
                context.phoneNumbers.Remove(number);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                new MessageBoxView("Error for remove Phone number", ex.Message).Show();
            }
        }

        public async Task DeletePhoneNumber(long numberId)
        {
            try
            {
                var pn = await context.phoneNumbers.FindAsync(numberId);
                context.phoneNumbers.Remove(pn);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                new MessageBoxView("Error for remove Phone number", ex.Message).Show();
            }
        }

        public async Task EditePhoneNumber(PhoneNumber number)
        {
            try
            {
                var pn = await context.phoneNumbers.Where(p => p.Id ==  number.Id).FirstOrDefaultAsync();
                if (pn != null)
                {
                    pn.TelPrefix = number.TelPrefix;
                    pn.Number = number.Number;
                    pn.Category = number.Category;

                    context.phoneNumbers.Update(pn);
                    await context.SaveChangesAsync();
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                new MessageBoxView("Error for update Phone number", ex.Message).Show();
            }
        }

        public async Task<List<PhoneNumber>> GetAll()
        {
            return await context.phoneNumbers.ToListAsync();
        }

        public async Task<List<PhoneNumber>> GetPhoneNumbersByOrganizationId(long organizationId)
        {
            return await context.phoneNumbers.Where(p => p.OrganizationId == organizationId).ToListAsync();
        }

        public async Task<List<PhoneNumber>> GetPhoneNumbersbyPersonId(long personId)
        {
            return await context.phoneNumbers.Where(p => p.PersonId == personId).ToListAsync();
        }
    }
}
