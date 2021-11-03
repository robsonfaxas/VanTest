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
    public class CourseVideoMapping : IEntityTypeConfiguration<CourseVideo>
    {
        public void Configure(EntityTypeBuilder<CourseVideo> builder)
        {
            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(x => x.Description)
                .IsRequired();

            builder.Property(x => x.Link)
                .IsRequired();

            builder.Property(x => x.Order)
                .IsRequired();

            builder.Property(x => x.IdCourse)
                .IsRequired();

            builder.HasOne<Course>()
                .WithMany( p=>p.Videos)
                .HasForeignKey(fk => fk.IdCourse);
        }
    }
}
