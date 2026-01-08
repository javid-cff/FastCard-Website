using FastCard.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace FastCard.Contexts
{
    public class FastCardDbContext : IdentityDbContext<AppUser>
    {
        public FastCardDbContext(DbContextOptions<FastCardDbContext> options) : base(options)
        {
            
        }
    }
}
