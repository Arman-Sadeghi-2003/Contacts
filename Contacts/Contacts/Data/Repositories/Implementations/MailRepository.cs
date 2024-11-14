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
    public class MailRepository : IMailRepository
    {
        private readonly ContactDbContext context;

        public MailRepository(ContactDbContext context)
        {
            this.context = context;
        }

        public async Task AddMail(Mail mail)
        {
            try
            {
                await context.mails.AddAsync(mail);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                new MessageBoxView("Error for add new mail", ex.Message).Show();
            }
        }

        public async Task DeleteMail(Mail mail)
        {
            try
            {
                context.mails.Remove(mail);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                new MessageBoxView("Error for remove mail", ex.Message).Show();
            }
        }

        public async Task DeleteMail(long mailId)
        {
            try
            {
                var m = await context.mails.FindAsync(mailId);
                if (m != null)
                {
                    context.mails.Remove(m);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                new MessageBoxView("Error for remove mail", ex.Message).Show();
            }
        }

        public async Task EditMail(Mail mail)
        {
            try
            {
                var m = await context.mails.FindAsync(mail.Id);
                if (m != null)
                {
                    m.MailAddress = mail.MailAddress;
                    m.Category = mail.Category;

                    context.mails.Update(m);
                    await context.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                new MessageBoxView("Error for edit mail", ex.Message).Show();
            }
        }

        public async Task<List<Mail>> GetAllMails()
        {
            return await context.mails.ToListAsync();
        }

        public async Task<List<Mail>> GetAllMailsByOrganizationId(long organizationId)
        {
            return await context.mails.Where(m => m.OrganizationId == organizationId).ToListAsync();
        }

        public async Task<List<Mail>> GetAllMailsByPersonId(long personId)
        {
            return await context.mails.Where(m => m.PersonId == personId).ToListAsync();
        }
    }
}
