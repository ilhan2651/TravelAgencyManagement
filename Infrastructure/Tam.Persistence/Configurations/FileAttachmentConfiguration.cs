using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Tam.Domain.Entities;

public class FileAttachmentConfiguration : IEntityTypeConfiguration<FileAttachment>
{
    public void Configure(EntityTypeBuilder<FileAttachment> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.FileName)
               .IsRequired()
               .HasMaxLength(200);

        builder.Property(x => x.FilePath)
               .IsRequired()
               .HasMaxLength(500);

        builder.Property(x => x.FileType)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(x => x.UploadedBy)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(x => x.UploadedAt)
               .HasDefaultValueSql("TIMEZONE('UTC', now())");

        builder.Property(x => x.EntityName)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(x => x.EntityId)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(x => x.CreatedAt)
               .HasDefaultValueSql("TIMEZONE('UTC', now())");
        builder.Property(x => x.UpdatedAt).IsRequired(false);
        builder.Property(x => x.DeletedAt).IsRequired(false);
    }
}

