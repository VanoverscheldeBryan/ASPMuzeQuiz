using System;
using System.Collections.Generic;
using System.Text;
using MuzeQuiz.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MuzeQuiz.Web.Data
{
    public class DevDbContext : IdentityDbContext<IdentityUser>
    {
        public DevDbContext(DbContextOptions<DevDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AppUser> AppUsers { get; set; }
        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Quiz> Quizzes { get; set; }
        public virtual DbSet<Scores> Scores { get; set; }

        public virtual DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); //must voor identity

            modelBuilder.Entity<Scores>().HasKey(e => new { e.AppUserId, e.QuizId });
        }



    }
}
