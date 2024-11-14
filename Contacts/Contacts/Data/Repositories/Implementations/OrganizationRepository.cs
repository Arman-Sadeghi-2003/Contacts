using Contacts.Data.DataContext;
using Contacts.Data.Repositories.Interfaces;
using Contacts.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Data.Repositories.Implementations
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly ContactDbContext context;

        public OrganizationRepository(ContactDbContext context)
        {
            this.context = context;
        }

        public async Task AddOrganization(Organization organization)
        {
            try
            {
                await context.Organizations.AddAsync(organization);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                new MessageBoxView("Error for add new organization", ex.Message).Show();
            }
        }

        public async Task DeleteOrganization(Organization organization)
        {
            try
            {
                context.Organizations.Remove(organization);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                new MessageBoxView("Error for remove organization", ex.Message).Show();
            }
        }

        public async Task DeleteOrganization(long organizationId)
        {
            try
            {
                var o = await context.Organizations.FindAsync(organizationId);
                context.Organizations.Remove(o);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                new MessageBoxView("Error for remove organization", ex.Message).Show();
            }
        }

        public async Task EditOrganization(Organization organization)
        {
            try
            {
                var o = await context.Organizations.FindAsync(organization.Id);
                if (o != null)
                {
                    o.Addreass = organization.Addreass;
                    o.Name = organization.Name;

                    context.Organizations.Update(o);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                new MessageBoxView("Error for update organization", ex.Message).Show();
            }
        }

        public async Task<List<Organization>> GetAllOrganizations()
        {
            return await context.Organizations.ToListAsync();
        }

        public async Task<Organization> GetOrganizationByPersonId(long personId)
        {
            return await context.Organizations.Where(o => o.PersonId == personId).FirstOrDefaultAsync() ?? new Organization();
        }
    }
}
