using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SHJ.BaseArchitecture.Domain.Dynamic;

namespace SHJ.BaseArchitecture.Infrastructure.Dynamic;

internal class PageConfig : IEntityTypeConfiguration<Page>
{
    public void Configure(EntityTypeBuilder<Page> builder)
    {
        builder.HasKey(_ => _.Id);

        builder.Property(_ => _.Title).IsRequired().HasMaxLength(PortalConsts.DefualtMaxLenght);
    }
}

