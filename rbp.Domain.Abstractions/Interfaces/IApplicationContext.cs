using Microsoft.EntityFrameworkCore;

namespace rbp.Domain.Abstractions.Interfaces
{
    public interface IApplicationContext
    {
        DbSet<Product> Products { get; set; }
    }
}
