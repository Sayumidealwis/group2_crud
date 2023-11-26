using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace simplecrud.Database{
    public class DBContext : DbContext{
        public DBContext(DbContextOptions<DBContext> options) : base(options){

        }
        
        public DbSet<Participant> Participant { get; set; }
    }
}