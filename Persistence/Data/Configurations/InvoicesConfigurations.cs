namespace Persistence.Data.Configurations;

public class InvoiceConfigurations : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        builder.HasKey(i => i.Id);
        builder.Property(i => i.TotalAmount).HasColumnType("decimal(8, 2)");

        builder.HasOne(i => i.Order)
               .WithOne(o => o.Invoice)
               .HasForeignKey<Invoice>(i => i.OrderId);
    }
}