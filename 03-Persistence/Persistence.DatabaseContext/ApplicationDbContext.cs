using Microsoft.AspNet.Identity.EntityFramework;
using Common;
using System.Data.Entity;
using Model.Domain;
using System.Reflection;
using System.Linq;
using Model.Helper;
using System;
using EntityFramework.DynamicFilters;
using Common.CustomFilters;
using Model.Auth;

namespace Persistence.DatabaseContext
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<ApplicationRole> ApplicationRole { get; set; }
        public DbSet<ApplicationUserRole> ApplicationUserRole { get; set; }

        public virtual DbSet<Student> Student { get;set; }
        public virtual DbSet<StudentPerCourse> StudentPerCourse { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Audience> Audience { get; set; }
        public virtual DbSet<Binnacle> Binnacle { get; set; }
        public virtual DbSet<BinnaclePhoto> BinnaclePhoto { get; set; }
        public virtual DbSet<BinnaclePhotoType> BinnaclePhotoType { get; set; }
        public virtual DbSet<External> External{ get; set; }
        public virtual DbSet<ExternalPhoto> ExternalPhoto { get; set; }
        public virtual DbSet<ExternalBinnacle> ExternalBinnacle { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<EventLocation> EventLocation { get; set; }
        public virtual DbSet<EventType> EventType { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<LocationUser> LocationUser { get; set; }
        public virtual DbSet<LocationTelephone> LocationTelephone { get; set; }
        public virtual DbSet<LocationType> LocationType { get; set; }
        public virtual DbSet<LocationUserNotification> LocationuserNotification { get; set; }
        public virtual DbSet<LocationVehicle> LocationVehicle { get; set; }
        public virtual DbSet<Notification> Notification { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }
        public virtual DbSet<PermissionUser> PermissionUser { get; set; }
        public virtual DbSet<PermissionRole> PermissionRole { get; set; }
        public virtual DbSet<UserBinnacle> UserBinnacle { get; set; }
        public virtual DbSet<ApplicationParameters> ApplicationParameters { get; set; }
        public virtual DbSet<Bulletin> Bulletin { get; set; }


        public ApplicationDbContext()
            : base(string.Format("name={0}", Parameters.AppContext))
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            AddMyFilters(ref modelBuilder);
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetAssembly(typeof(ApplicationDbContext)));

            modelBuilder.Entity<PermissionUser>().HasRequired(s => s.Permission).WithMany().HasForeignKey(u => u.Permission_Id);

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            MakeAudit();
            return base.SaveChanges();
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        private void MakeAudit()
        {
            var modifiedEntries = ChangeTracker.Entries().Where(
                x => x.Entity is AuditEntity
                    && (
                    x.State == EntityState.Added
                    || x.State == EntityState.Modified
                    || x.State == EntityState.Deleted
                )
            );

            foreach (var entry in modifiedEntries)
            {
                var entity = entry.Entity as AuditEntity;
                if (entity != null)
                {
                    var date = DateTime.Now;
                    var userId = CurrentUserHelper.Get != null ? CurrentUserHelper.Get.UserId : null;

                    if (entry.State == EntityState.Added)
                    {
                        entity.CreatedAt = date;
                        entity.CreatedBy = userId;
                    }
                    else if (entity is ISoftDeleted && ((ISoftDeleted)entity).Deleted)
                    {
                        entity.DeletedAt = date;
                        entity.DeletedBy = userId;
                    }

                    Entry(entity).Property(x => x.CreatedAt).IsModified = false;
                    Entry(entity).Property(x => x.CreatedBy).IsModified = false;

                    entity.UpdatedAt = date;
                    entity.UpdatedBy = userId;
                }
            }
        }

        private void AddMyFilters(ref DbModelBuilder modelBuilder)
        {
            modelBuilder.Filter(Enums.MyFilters.IsDeleted.ToString(), (ISoftDeleted ea) => ea.Deleted, false);
        }
    }
}
