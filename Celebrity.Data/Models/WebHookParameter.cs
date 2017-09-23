namespace Celebrity.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class WebHookParameter : DataModel<Guid>
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        public string Value { get; set; }

        [ForeignKey(nameof(WebHook))]
        public Guid WebHookId { get; set; }
    }
}