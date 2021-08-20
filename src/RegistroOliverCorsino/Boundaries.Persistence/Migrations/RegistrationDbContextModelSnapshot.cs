﻿// <auto-generated />
using System;
using Boundaries.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Boundaries.Persistence.Migrations
{
    [DbContext(typeof(RegistrationDbContext))]
    partial class RegistrationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Core.Models.ContactInformation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ContactInformationTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ContactInformationTypeId")
                        .IsUnique();

                    b.HasIndex("Description")
                        .IsUnique()
                        .HasDatabaseName("IDX_CONTACT_INFORMATION_DESCRIPTION");

                    b.HasIndex("UserId");

                    b.ToTable("ContactInformation");
                });

            modelBuilder.Entity("Core.Models.ContactInformationType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.HasKey("Id");

                    b.HasIndex("Description")
                        .IsUnique()
                        .HasDatabaseName("IDX_CONTACT_INFORMATION_TYPE_DESCRIPTION");

                    b.ToTable("ContactInformationTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Correo electrónico"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Teléfono móvil"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Teléfono fijo"
                        });
                });

            modelBuilder.Entity("Core.Models.EducationLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.HasKey("Id");

                    b.HasIndex("Description")
                        .IsUnique()
                        .HasDatabaseName("IDX_EDUCATION_LEVEL_DESCRIPTION");

                    b.ToTable("EducationLevels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Bachiller"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Universitaria"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Postgrado"
                        });
                });

            modelBuilder.Entity("Core.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.HasKey("Id");

                    b.HasIndex("Description")
                        .IsUnique()
                        .HasDatabaseName("IDX_ROLE_DESCRIPTION");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "No califica"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Empadronador(a)"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Supervisor(a)"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Coordinador(a)"
                        });
                });

            modelBuilder.Entity("Core.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<int>("EducationLevelId")
                        .HasColumnType("int");

                    b.Property<string>("IdentificationNumber")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("varchar(13)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("RegistrationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EducationLevelId")
                        .IsUnique();

                    b.HasIndex("IdentificationNumber")
                        .IsUnique()
                        .HasDatabaseName("IDX_USER_IDENTIFICATION_NUMBER");

                    b.HasIndex("RoleId")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Core.Models.ContactInformation", b =>
                {
                    b.HasOne("Core.Models.ContactInformationType", "ContactInformationType")
                        .WithOne("ContactInformation")
                        .HasForeignKey("Core.Models.ContactInformation", "ContactInformationTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Models.User", "User")
                        .WithMany("ContactInformation")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ContactInformationType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Core.Models.User", b =>
                {
                    b.HasOne("Core.Models.EducationLevel", "EducationLevel")
                        .WithOne("User")
                        .HasForeignKey("Core.Models.User", "EducationLevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Models.Role", "Role")
                        .WithOne("User")
                        .HasForeignKey("Core.Models.User", "RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EducationLevel");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Core.Models.ContactInformationType", b =>
                {
                    b.Navigation("ContactInformation");
                });

            modelBuilder.Entity("Core.Models.EducationLevel", b =>
                {
                    b.Navigation("User");
                });

            modelBuilder.Entity("Core.Models.Role", b =>
                {
                    b.Navigation("User");
                });

            modelBuilder.Entity("Core.Models.User", b =>
                {
                    b.Navigation("ContactInformation");
                });
#pragma warning restore 612, 618
        }
    }
}
