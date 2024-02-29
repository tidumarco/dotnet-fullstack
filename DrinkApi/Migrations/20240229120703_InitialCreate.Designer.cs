﻿// <auto-generated />
using System;
using DrinkApi.Data;
using DrinkApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DrinkApi.Migrations
{
	[DbContext(typeof(DrinkContext))]
	[Migration("20240229120703_InitialCreate")]
	partial class InitialCreate
	{
		/// <inheritdoc />
		protected override void BuildTargetModel(ModelBuilder modelBuilder)
		{
#pragma warning disable 612, 618
			modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

			modelBuilder.Entity("DrinkApi.Models.Drink", b =>
				{
					b.Property<int?>("Id")
						.ValueGeneratedOnAdd()
						.HasColumnType("INTEGER");

					b.Property<string>("StrDrink")
						.HasMaxLength(50)
						.HasColumnType("TEXT");

					b.Property<string>("StrDrinkThumb")
						.HasColumnType("TEXT");

					b.HasKey("Id");

					b.ToTable("Drinks");
				});
#pragma warning restore 612, 618
		}
	}
}
