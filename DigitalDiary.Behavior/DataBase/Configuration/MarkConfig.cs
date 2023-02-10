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
    internal class MarkConfig : IEntityTypeConfiguration<Mark>
    {
        public void Configure(EntityTypeBuilder<Mark> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(u => u.Work)
                 .WithMany(u => u.Marks)
                 .HasForeignKey(u => u.WorkId);

        }
    }
}
