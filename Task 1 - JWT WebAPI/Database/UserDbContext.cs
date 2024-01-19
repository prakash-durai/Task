using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuizAPI.Models;

namespace QuizAPI.Database
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User>? Users{ get; set; }
        public DbSet<Scoreboard>? Scoreboards { get; set; }
    }
}