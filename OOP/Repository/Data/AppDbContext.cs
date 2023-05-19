using Microsoft.EntityFrameworkCore;
using Plugin.Authorization;
using Plugin.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<GrammaTask> GrammaTasks { get; set; }
        public DbSet<InsertTask> InsertTasks { get; set; }
        public DbSet<VocabluaryTask> VocabluaryTasks { get; set; }
        public DbSet<SentenceTask> SentenceTasks { get; set; }
    }
}
