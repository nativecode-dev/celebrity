using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Celebrity.Data.Models
{
    public class OrganizationIdentityUser : DataModel<Guid>
    {
        [ForeignKey(nameof(IdentityUser))]
        public string IdentityUserId { get; set; }

        [ForeignKey(nameof(Organization))]
        public Guid OrganizationId { get; set; }
    }
}