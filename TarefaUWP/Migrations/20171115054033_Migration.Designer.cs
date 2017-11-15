using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TarefaUWP.Data;

namespace TarefaUWP.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20171115054033_Migration")]
    partial class MigrationUWP
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.3");

            modelBuilder.Entity("TarefaUWP.Model.Lancamentos", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataLancamento");

                    b.Property<string>("Descricao");

                    b.Property<string>("Tipo");

                    b.Property<double>("Valor");

                    b.HasKey("Id");

                    b.ToTable("DBLancamentos");
                });
        }
    }
}
