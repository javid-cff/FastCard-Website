using FastCard.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace FastCard.Contexts
{
    public class FastCardDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<Product> Products { get; set; }
        public FastCardDbContext(DbContextOptions<FastCardDbContext> options) : base(options)
        {
            
        }
    }
}
