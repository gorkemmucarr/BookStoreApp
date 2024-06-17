using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Config
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(p => p.BookId);
            builder.Property(p => p.BookName).IsRequired();
            builder.Property(p => p.Writer).IsRequired();
            builder.Property(p => p.Price).IsRequired();

            builder.HasData(new Book()
            {
                BookId=1,
                CategoryId = 1,
                BookName = "Aşk-ı Memnu",
                Writer = "Halit Ziya Uşaklıgil",
                Price = 150,
                ImageUrl = "/images/askimemnu.jpg"
            },
            new Book()
            {
                BookId = 2,
                CategoryId = 2,
                BookName = "Benim Adım Kırmızı",
                Writer = "Orhan Pamuk",
                Price = 100,
                ImageUrl = "/images/benimadimkirmizi.jpg"
            },
            new Book()
            {
                BookId = 3,
                CategoryId = 3,
                BookName = "Puslu Kıtalar Atlası",
                Writer = "İhsan Oktay Anar",
                Price = 250,
                ImageUrl = "/images/puslukitalaratlasi.jpg"
            },
            new Book()
            {
                BookId = 4,
                CategoryId = 4,
                BookName = "Sevgili Arsız Ölüm",
                Writer = "Latife Tekin",
                Price = 350,
                ImageUrl = "/images/sevgiliarsizolum.jpg"
            },
            new Book()
            {
                BookId = 5,
                CategoryId = 1,
                BookName = "Tehlikeli Oyunlar",
                Writer = "Oğuz Atay",
                Price = 150,
                ImageUrl = "/images/tehlikelioyunlar.jpg"
            });
        }
    }
}
