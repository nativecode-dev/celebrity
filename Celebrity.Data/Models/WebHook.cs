namespace Celebrity.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Core;

    public class WebHook : DataModel<Guid>
    {
        [Required]
        [StringLength(CommonLengths.Slug)]
        public string Name { get; set; }

        [ForeignKey(nameof(Organization))]
        public Guid OrganizationId { get; set; }

        public virtual ICollection<WebHookParameter> Parameters { get; set; } = new List<WebHookParameter>();

        [Required]
        [StringLength(CommonLengths.Url)]
        public string Url { get; set; }
    }
}