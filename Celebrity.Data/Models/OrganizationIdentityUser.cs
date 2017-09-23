namespace Celebrity.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.AspNetCore.Identity;

    public class OrganizationIdentityUser : DataModel<Guid>
    {
        [ForeignKey(nameof(IdentityUser))]
        public string IdentityUserId { get; set; }

        [ForeignKey(nameof(Organization))]
        public Guid OrganizationId { get; set; }
    }
}