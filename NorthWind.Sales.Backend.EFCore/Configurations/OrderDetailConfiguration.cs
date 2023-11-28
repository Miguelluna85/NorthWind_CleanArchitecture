namespace NorthWind.Sales.Backend.EFCore.Configurations
{
    internal class OrderDetailConfiguration :
        IEntityTypeConfiguration<Entities.OrderDetail>
    {

        public void Configure(EntityTypeBuilder<Entities.OrderDetail> builder)
        {
            builder.HasKey(d => new { d.OrderId, d.ProductId });

            builder.Property(d => d.UnitPrice)
                .HasPrecision(8, 2);


            builder.HasOne<Product>()
                .WithMany()
                .HasForeignKey(d => d.ProductId);

        }
    }
}
