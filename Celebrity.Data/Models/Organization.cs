namespace Celebrity.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Organization : DataModel<Guid>
    {
        public string Description { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Required]
        [StringLength(128)]
        public string Slug { get; set; }

        public virtual ICollection<OrganizationIdentityUser> Users { get; set; }

        public virtual ICollection<WebHook> WebHooks { get; set; } = new List<WebHook>();

        [StringLength(256)]
        public string Website { get; set; }
    }
}