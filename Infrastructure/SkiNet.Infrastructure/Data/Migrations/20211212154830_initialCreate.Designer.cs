#nullable disable

namespace SkiNet.Infrastructure.Data.Migrations;

[DbContext(typeof(DataContext))]
[Migration("20211212154830_initialCreate")]
partial class initialCreate
{
    protected override void BuildTargetModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
        modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

        modelBuilder.Entity("SkiNet.Api.Entities.Product", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("INTEGER");

                b.Property<string>("ProductName")
                    .IsRequired()
                    .HasColumnType("TEXT");

                b.HasKey("Id");

                b.ToTable("Products");
            });
#pragma warning restore 612, 618
    }
}

