﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using avaliacoes.Models;

namespace dpApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20190601200728_AvaliacoesInicial")]
    partial class AvaliacoesInicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("avaliacoes.Models.Avaliacao", b =>
                {
                    b.Property<int>("AvaliacaoId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Ao1");

                    b.Property<int>("Ao10");

                    b.Property<int>("Ao11");

                    b.Property<int>("Ao12");

                    b.Property<int>("Ao13");

                    b.Property<int>("Ao14");

                    b.Property<int>("Ao15");

                    b.Property<int>("Ao16");

                    b.Property<int>("Ao17");

                    b.Property<int>("Ao18");

                    b.Property<int>("Ao19");

                    b.Property<int>("Ao2");

                    b.Property<int>("Ao20");

                    b.Property<int>("Ao21");

                    b.Property<int>("Ao22");

                    b.Property<int>("Ao23");

                    b.Property<int>("Ao24");

                    b.Property<int>("Ao25");

                    b.Property<int>("Ao26");

                    b.Property<int>("Ao27");

                    b.Property<int>("Ao28");

                    b.Property<int>("Ao29");

                    b.Property<int>("Ao2_1");

                    b.Property<int>("Ao2_2");

                    b.Property<int>("Ao3");

                    b.Property<int>("Ao30");

                    b.Property<int>("Ao31");

                    b.Property<int>("Ao32");

                    b.Property<int>("Ao33");

                    b.Property<int>("Ao34");

                    b.Property<int>("Ao35");

                    b.Property<int>("Ao36");

                    b.Property<int>("Ao37");

                    b.Property<int>("Ao38");

                    b.Property<int>("Ao39");

                    b.Property<int>("Ao4");

                    b.Property<int>("Ao40");

                    b.Property<int>("Ao41");

                    b.Property<int>("Ao42");

                    b.Property<int>("Ao43");

                    b.Property<int>("Ao44");

                    b.Property<int>("Ao5");

                    b.Property<int>("Ao6");

                    b.Property<int>("Ao7");

                    b.Property<int>("Ao8");

                    b.Property<int>("Ao9");

                    b.Property<DateTime>("Criada_em");

                    b.Property<string>("Email");

                    b.Property<string>("Nome");

                    b.Property<string>("TipoAvaliacao");

                    b.HasKey("AvaliacaoId");

                    b.ToTable("Avaliacao");
                });
#pragma warning restore 612, 618
        }
    }
}
