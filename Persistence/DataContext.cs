﻿using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DbSet<Perfume> Perfumes { get; set; }

        public DataContext(DbContextOptions options): base(options) { }
        

    }
}