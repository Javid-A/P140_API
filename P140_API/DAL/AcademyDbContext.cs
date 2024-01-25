﻿using Microsoft.EntityFrameworkCore;
using P140_API.Entities;

namespace P140_API.DAL
{
    public class AcademyDbContext:DbContext
    {
        public AcademyDbContext(DbContextOptions<AcademyDbContext> options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
    }
}
