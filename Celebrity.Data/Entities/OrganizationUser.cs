namespace Celebrity.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using Identity;

    public class OrganizationUser : Entity<Guid>
    {
        public User User { get; set; }

        [ForeignKey(nameof(Identity.User))]
        public Guid UserId { get; set; }

        public Organization Organization { get; set; }

        [ForeignKey(nameof(Entities.Organization))]
        public Guid OrganizationId { get; set; }
    }
}