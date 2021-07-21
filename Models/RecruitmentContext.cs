using Microsoft.EntityFrameworkCore;
using Recruitment.Models;

namespace Recruitment.Models
{
    public class RecruitmentContext : DbContext
    {
        public RecruitmentContext(DbContextOptions<RecruitmentContext> options)
            : base(options)
        {
        }

        public DbSet<DetailsList> DetailsLists { get; set; }

        
    }
}