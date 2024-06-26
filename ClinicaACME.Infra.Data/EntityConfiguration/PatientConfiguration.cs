﻿using ClinicaACME.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicaACME.Infra.Data.EntityConfiguration
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("pacientes");

            builder.Property(x => x.Id).IsRequired().HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired().HasColumnName("nome").HasMaxLength(150);
            builder.Property(x => x.BirthDate).IsRequired().HasColumnName("data_de_nascimento");
            builder.Property(x => x.Cpf).IsRequired().HasColumnName("cpf").HasMaxLength(11);
            builder.Property(x => x.Gender).IsRequired().HasColumnName("sexo").HasMaxLength(1);
            builder.Property(x => x.Address).HasColumnName("endereco").HasMaxLength(255);
            builder.Property(x => x.Status).IsRequired().HasColumnName("status").HasDefaultValue(true);

            // Adiciona index unico para o campo CPF.
            builder.HasIndex(x => x.Cpf).IsUnique();

        }
    }
}
