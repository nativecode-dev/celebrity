namespace Celebrity.Data.Entities.Identity
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserRole : Entity<Guid>
    {
        public Role Role { get; set; }

        [ForeignKey(nameof(Identity.Role))]
        public Guid RoleId { get; set; }

        public User User { get; set; }

        [ForeignKey(nameof(Identity.User))]
        public Guid UserId { get; set; }
    }
}