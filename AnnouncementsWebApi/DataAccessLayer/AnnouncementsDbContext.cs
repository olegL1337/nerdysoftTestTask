using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public class AnnouncementsDbContext:DbContext
    {
        public DbSet<Announcement> Announcements { get; set; }
        public AnnouncementsDbContext(DbContextOptions<AnnouncementsDbContext> opt):base(opt)
        {

        }
    }
}
