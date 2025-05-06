using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Models;

namespace Models.Data.Configrations
{
    public class Task1Config : IEntityTypeConfiguration<Task1>
    {
        public void Configure(EntityTypeBuilder<Task1> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired();
          
            
                
        }
    }
}
