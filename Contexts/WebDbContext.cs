using JobBoardCRUD.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobBoardCRUD.Contexts
{
    public class WebDbContext: DbContext
    {
        public WebDbContext(DbContextOptions<WebDbContext> options) : base(options)
        { 
            
        }

        public DbSet<Job> Jobs { get; set; }
    }
}
