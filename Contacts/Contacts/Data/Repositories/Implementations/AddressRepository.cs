using Contacts.Data.DataContext;
using Contacts.Data.Repositories.Interfaces;
using Contacts.Models.Entities.ContactDetails;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace Contacts.Data.Repositories.Implementations
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ContactDbContext context;

        public AddressRepository(ContactDbContext context)
        {
            this.context = context;
        }

        public async Task AddAddress(Address address)
        {
            try
            {
                await context.Addresses.AddAsync(address);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                new MessageBoxView("Error for add new address", ex.Message).Show();
            }
        }

        public async Task DeleteAddress(Address address)
        {
            try
            {
                context.Addresses.Remove(address);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                new MessageBoxView("Error for remove address", ex.Message).Show();
            }
        }

        public async Task DeleteAddress(long addressId)
        {
            try
            {
                var a = await context.Addresses.FindAsync(addressId);
                if (a != null)
                {
                    context.Addresses.Remove(a);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                new MessageBoxView("Error for remove address", ex.Message).Show();
            }
        }

        public async Task EditAddress(Address address)
        {
            try
            {
                var a = await context.Addresses.FindAsync(address.Id);
                if (a != null)
                {
                    a.Content = address.Content;

                    context.Addresses.Update(a);
                    await context.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                new MessageBoxView("Error for edit address", ex.Message).Show();
            }
        }

        public async Task<List<Address>> GetAddressesByPersonId(long personId)
        {
            return await context.Addresses.Where(a => a.PersonId == personId).ToListAsync();
        }

        public async Task<List<Address>> GetAllAddresses()
        {
            return await context.Addresses.ToListAsync();
        }
    }
}
