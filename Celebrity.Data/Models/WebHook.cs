namespace Celebrity.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class WebHook : DataModel<Guid>
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [ForeignKey(nameof(Organization))]
        public Guid OrganizationId { get; set; }

        public ICollection<WebHookParameter> Parameters { get; set; } = new List<WebHookParameter>();

        [Required]
        [StringLength(1024)]
        public string Url { get; set; }
    }
}