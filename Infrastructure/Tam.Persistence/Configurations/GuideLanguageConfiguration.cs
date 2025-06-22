using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Domain.Entities.JoinTables;

namespace Tam.Persistence.Configurations
{
    public class GuideLanguageConfiguration : IEntityTypeConfiguration<GuideLanguage>
    {
        public void Configure(EntityTypeBuilder<GuideLanguage> builder)
        {
            builder.HasKey(x => new { x.GuideId, x.LanguageId });

            builder.HasOne(x => x.Guide)
                   .WithMany()
                   .HasForeignKey(x => x.GuideId);

            builder.HasOne(x => x.Language)
                   .WithMany()
                   .HasForeignKey(x => x.LanguageId);
        }
    }

}
