namespace Celebrity.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using Identity;

    public class OrganizationUser : DataModel<Guid>
    {
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }

        [ForeignKey(nameof(Organization))]
        public Guid OrganizationId { get; set; }
    }
}