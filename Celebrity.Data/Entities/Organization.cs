namespace Celebrity.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Core;

    public class Organization : Entity<Guid>
    {
        public string Description { get; set; }

        [Required]
        [StringLength(CommonLengths.Slug)]
        public string Name { get; set; }

        [Required]
        [StringLength(CommonLengths.Slug)]
        public string Slug { get; set; }

        public virtual ICollection<OrganizationUser> Users { get; set; }

        public virtual ICollection<WebHook> WebHooks { get; set; } = new List<WebHook>();

        [StringLength(CommonLengths.Url)]
        public string Website { get; set; }
    }
}