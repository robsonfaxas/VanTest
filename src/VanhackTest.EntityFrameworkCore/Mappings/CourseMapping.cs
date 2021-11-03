using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanhackTest.Authorization.Roles;
using VanhackTest.Domain;

namespace VanhackTest.Mappings
{
    public class CourseMapping : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(x => x.Description)
                .IsRequired();

            builder.Property(x => x.RoleId)
                .IsRequired();

            builder
                .HasOne<Role>()
                .WithMany()
                .HasForeignKey(fk => fk.RoleId);            

        }
    }
}
