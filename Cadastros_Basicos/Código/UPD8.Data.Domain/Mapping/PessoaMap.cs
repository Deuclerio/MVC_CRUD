using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UPD8.Data.Domain.Entity;

namespace UPD8.Data.Domain.Mapping
{
    public  class PessoaMap : IEntityTypeConfiguration<PessoaEntity>
    {
        public void Configure(EntityTypeBuilder<PessoaEntity> builder)
        {

            builder.ToTable("Pessoa");

            builder.HasKey(prop => prop.Id).HasName("Id");
            builder.Property(prop => prop.Id)
                   .HasColumnName("Id").ValueGeneratedOnAdd();

            builder.Property(prop => prop.UserDetailsRegisterId)
                    .HasConversion(prop => prop, prop => prop)
                    .IsRequired()
                    .HasColumnName("UserRegistrouId")
                    .HasColumnType("bigint");

            builder.Property(prop => prop.UserDetailsUpdateId)
                    .HasConversion(prop => prop, prop => prop)
                    .IsRequired(false)
                    .HasColumnName("UserAtualizouId")
                    .HasColumnType("bigint");

            builder.Property(prop => prop.Nome)
                    .HasConversion(prop => prop.ToString(), prop => prop)
                    .IsRequired()
                    .HasColumnName("Nome")
                    .HasColumnType("nvarchar(500)");
        }
    }
}
