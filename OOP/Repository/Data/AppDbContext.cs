
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Plugin.Authorization;
using Plugin.Tasks;


namespace Repository.Data
{
    public class AppDbContext : IdentityDbContext
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
