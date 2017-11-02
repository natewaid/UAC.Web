using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UAC.Web.Entities
{
    public class CustomerUserDbContext : IdentityDbContext<CustomerUser>
    {
        public CustomerUserDbContext(string connectionString) : base(connectionString) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var user = modelBuilder.Entity<CustomerUser>();

            user.Property(x => x.FirstName).IsRequired().HasMaxLength(256)
                .HasColumnAnnotation("Index", new IndexAnnotation(
                    new IndexAttribute("FirstNameIndex")));

            user.Property(x => x.LastName).IsRequired().HasMaxLength(256)
                .HasColumnAnnotation("Index", new IndexAnnotation(
                    new IndexAttribute("LastNameIndex")));              
        }
    }
}
