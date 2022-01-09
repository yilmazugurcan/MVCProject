using COMMON;
using CORE;
using DataAccess.Entity;
using DataAccess.MAP;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext()
        {
            Database.Connection.ConnectionString = "Server=LAPTOP-07LGIPAN;Database=project;Trusted_Connection=True;";
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<AppUserAndRole> AppUserAndRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new SubCategoryMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new AppUserMap());
            modelBuilder.Configurations.Add(new RoleMap());
            modelBuilder.Configurations.Add(new AppUserAndRoleMap());

            base.OnModelCreating(modelBuilder);
        }

     
        public override int SaveChanges()
        {
            var modifiedEntiries = ChangeTracker.Entries().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);

            string identiy= WindowsIdentity.GetCurrent().Name;
            string computer= Environment.MachineName;
            DateTime dateTime = DateTime.Now;
            string ip= IPAddresses.GetHostName();
            string username = WebCookie.UserName;

            try
            {
                foreach (var item in modifiedEntiries)
                {
                    var entityRepository = item.Entity as CoreEntity;

                    if (entityRepository != null)
                    {
                        if (item.State == EntityState.Added)
                        {
                            entityRepository.CreatedAdUsername = identiy;
                            entityRepository.CreatedBy = "admin";
                            entityRepository.CreatedComputerName = computer;
                            entityRepository.CreatedIP = ip;
                            entityRepository.CreatedDate = dateTime;
                        }
                        else if(item.State==EntityState.Modified)
                        {
                            entityRepository.ModifiedAdUsername = identiy;
                            entityRepository.ModifiedBy = "admin";
                            entityRepository.ModifiedComputerName = computer;
                            entityRepository.ModifiedIP = ip;
                            entityRepository.ModifiedDate = dateTime;
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }


            return base.SaveChanges();
        }
    }
}
