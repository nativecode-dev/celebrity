namespace Celebrity.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using Identity;

    public class OrganizationUser : DataModel<Guid>
    {
        public User User { get; set; }

        [ForeignKey(nameof(Identity.User))]
        public Guid UserId { get; set; }

        public Organization Organization { get; set; }

        [ForeignKey(nameof(Models.Organization))]
        public Guid OrganizationId { get; set; }
    }
}