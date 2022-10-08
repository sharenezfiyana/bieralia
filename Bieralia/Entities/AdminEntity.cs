using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bieralia.Entities
{
    public class AdminEntity
    {
        public Guid UserID { get; set; }
        public string Username { get; set; }
        public DateTime? DOB { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
    }

    public class AdminEntityModelBuilder : IEntityTypeConfiguration<AdminEntity>
    {
        public void Configure(EntityTypeBuilder<AdminEntity> entity)
        {
            entity.HasKey(e => e.UserID);
        }
    }
}
