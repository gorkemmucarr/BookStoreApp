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
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(p => p.CategoryId);
            builder.Property(p => p.CategoryName).IsRequired();

            builder.HasData(new Category()
            {
                CategoryId = 1,
                CategoryName="Macera"
            }, 
            new Category()
            {
                CategoryId = 2,
                CategoryName = "Aşk"
            }, 
            new Category()
            {
                CategoryId = 3,
                CategoryName = "Komedi"
            },
            new Category()
            {
                CategoryId = 4,
                CategoryName = "Korku"
            });
        }
    }
}

