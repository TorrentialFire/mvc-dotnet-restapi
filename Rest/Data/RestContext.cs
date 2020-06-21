
using Microsoft.EntityFrameworkCore;
using Rest.Models;

namespace Rest.Data 
{
    public class RestContext : DbContext
    {
        public RestContext(DbContextOptions<RestContext> opt) : base(opt) {}

        public DbSet<Command> Commands { get; set; }
    }
}