using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class AnnouncementRepository
    {
        AnnouncementsDbContext context;
        public AnnouncementRepository(AnnouncementsDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Announcement>> GetAll()
        {
            return await context.Announcements.ToListAsync();
        }
        public async Task<Announcement> GetAnnouncement(int id)
        {
            return await context.Announcements.FindAsync(id);
        }
        public async Task AddAnnouncement(Announcement ann)
        {
            await context.Announcements.AddAsync(ann);
            await context.SaveChangesAsync();
        }
        public async Task RemoveAnnouncement(Announcement ann)
        {
            context.Announcements.Remove(ann);
            await context.SaveChangesAsync();
        }
        public async Task EditAnnouncement(Announcement ann)
        {
            context.Entry(ann).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
