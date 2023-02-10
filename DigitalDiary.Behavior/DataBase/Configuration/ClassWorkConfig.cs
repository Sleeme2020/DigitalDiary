using DigitalDiary.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalDiary.Behavior.DataBase.Configuration
{
    internal class ClassWorkConfig : IEntityTypeConfiguration<ClassWork>
    {
        public void Configure(EntityTypeBuilder<ClassWork> builder)
        {
            
            builder.HasIndex(u=>new {u.SubjectId,u.GroupId,u.TeacherId,u.Date,u.PairWorkId}).IsUnique();
            builder.HasMany(u => u.HomeWorks)
                 .WithOne(u => u.ClassWork)
                 .HasForeignKey(u => u.ClassWorkId);
           
            
                
            
            //builder.ToTable("ClassWork",u=>u.Property(u=>u.Marks)).OwnsMany(u=>u.Marks)
            //    .(u=>u.Work);
            
        }
    }
}
