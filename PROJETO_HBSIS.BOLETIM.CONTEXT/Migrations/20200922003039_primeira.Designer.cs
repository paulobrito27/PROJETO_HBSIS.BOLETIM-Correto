﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PROJETO_HBSIS.BOLETIM.CONTEXT;

namespace PROJETO_HBSIS.BOLETIM.CONTEXT.Migrations
{
    [DbContext(typeof(BancoContext))]
    [Migration("20200922003039_primeira")]
    partial class primeira
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PROJETO_HBSIS.BOLETIM.MODELS.Administrador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sobrenome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoUsuario")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Administradors");
                });

            modelBuilder.Entity("PROJETO_HBSIS.BOLETIM.MODELS.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CursoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdCurso")
                        .HasColumnType("int");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sobrenome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoUsuario")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CursoId");

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("PROJETO_HBSIS.BOLETIM.MODELS.ClassesAssociativas.AlunoMateria", b =>
                {
                    b.Property<int>("AlunoId")
                        .HasColumnType("int");

                    b.Property<int>("MateriaId")
                        .HasColumnType("int");

                    b.Property<double>("Nota")
                        .HasColumnType("float");

                    b.HasKey("AlunoId", "MateriaId");

                    b.HasIndex("MateriaId");

                    b.ToTable("AlunoMateria");
                });

            modelBuilder.Entity("PROJETO_HBSIS.BOLETIM.MODELS.ClassesAssociativas.MateriaCurso", b =>
                {
                    b.Property<int>("CursoId")
                        .HasColumnType("int");

                    b.Property<int>("MateriaId")
                        .HasColumnType("int");

                    b.HasKey("CursoId", "MateriaId");

                    b.HasIndex("MateriaId");

                    b.ToTable("MateriaCurso");
                });

            modelBuilder.Entity("PROJETO_HBSIS.BOLETIM.MODELS.ClassesAssociativas.ProfessorMateria", b =>
                {
                    b.Property<int>("ProfessorId")
                        .HasColumnType("int");

                    b.Property<int>("MateriaId")
                        .HasColumnType("int");

                    b.HasKey("ProfessorId", "MateriaId");

                    b.HasIndex("MateriaId");

                    b.ToTable("ProfessorMateria");
                });

            modelBuilder.Entity("PROJETO_HBSIS.BOLETIM.MODELS.Curso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Situacao")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("PROJETO_HBSIS.BOLETIM.MODELS.Materia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Situacao")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Materias");
                });

            modelBuilder.Entity("PROJETO_HBSIS.BOLETIM.MODELS.Professor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sobrenome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoUsuario")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Professors");
                });

            modelBuilder.Entity("PROJETO_HBSIS.BOLETIM.MODELS.Aluno", b =>
                {
                    b.HasOne("PROJETO_HBSIS.BOLETIM.MODELS.Curso", "Curso")
                        .WithMany("Alunos")
                        .HasForeignKey("CursoId");
                });

            modelBuilder.Entity("PROJETO_HBSIS.BOLETIM.MODELS.ClassesAssociativas.AlunoMateria", b =>
                {
                    b.HasOne("PROJETO_HBSIS.BOLETIM.MODELS.Aluno", "Aluno")
                        .WithMany("AlunoMaterias")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PROJETO_HBSIS.BOLETIM.MODELS.Materia", "Materia")
                        .WithMany("AlunoMaterias")
                        .HasForeignKey("MateriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PROJETO_HBSIS.BOLETIM.MODELS.ClassesAssociativas.MateriaCurso", b =>
                {
                    b.HasOne("PROJETO_HBSIS.BOLETIM.MODELS.Curso", "Curso")
                        .WithMany("Materias")
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PROJETO_HBSIS.BOLETIM.MODELS.Materia", "Materia")
                        .WithMany("Cursos")
                        .HasForeignKey("MateriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PROJETO_HBSIS.BOLETIM.MODELS.ClassesAssociativas.ProfessorMateria", b =>
                {
                    b.HasOne("PROJETO_HBSIS.BOLETIM.MODELS.Materia", "Materia")
                        .WithMany("ProfessorMaterias")
                        .HasForeignKey("MateriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PROJETO_HBSIS.BOLETIM.MODELS.Professor", "Professor")
                        .WithMany("ProfessorMaterias")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
