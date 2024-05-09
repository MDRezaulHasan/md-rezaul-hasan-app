using Microsoft.EntityFrameworkCore;

namespace MdRezaulHasan.Api;

public class DataContext:DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }
    public DbSet<Project> Projects { get; set; }
}
