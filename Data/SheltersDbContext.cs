using Microsoft.EntityFrameworkCore;

namespace ShelterApi.Data;

public class SheltersDbContext : DbContext
{
    public SheltersDbContext(DbContextOptions<SheltersDbContext> options)
        : base(options)
    {
    }

}

