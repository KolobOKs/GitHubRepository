﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using MasterGradeSearch.Core.Commons;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MasterGradeSearch.Web.Models
{
    /// <summary>
    ///     СМОТРИ КЛАСС НИЖЕ.
    ///     конкретно этот тип у тебя не испльзуется
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            ClaimsIdentity userIdentity =
                await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    /// <summary>
    ///     Класс, обеспечиващий связь с базой данных.
    ///     Обеспечивает взаимодейтствие с базой данных: получение, создание, изменение и удаление объектов (город, районы, вузы и пр).
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", false)
        {
        }

        #region Overrides of IdentityDbContext<ApplicationUser,IdentityRole,string,IdentityUserLogin,IdentityUserRole,IdentityUserClaim>

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Course>()
           .HasMany(x => x.Exams)
           .WithMany(x => x.Courses)
           .Map(c =>
           {
               c.MapLeftKey("CourseId");
               c.MapRightKey("ExamId");
               c.ToTable("CoursesToExamMapping");
           });

            modelBuilder.Entity<Exam>()
               .HasMany(x => x.Courses)
               .WithMany(x => x.Exams)
               .Map(c =>
               {
                   c.MapLeftKey("ExamId");
                   c.MapRightKey("CourseId");
                   c.ToTable("CoursesToExamMapping");
               });
        }

        #endregion

        public DbSet<City> Cities { get; set; }

        public DbSet<District> Districts { get; set; }

        public DbSet<Exam> Exams { get; set; }

        public DbSet<Institute> Institutes { get; set; }

        public DbSet<Discipline> Disciplines { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Criterion> Сriterions { get; set; }

        public DbSet<CriterionRatio> CriterionRatios { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}