namespace Persistence.Data.Configurations;

public class ProductsConfigurations : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Price).HasColumnType("decimal(8,2)");
    }
}
