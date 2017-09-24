namespace Celebrity.Data.Models.Identity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Core;
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser<Guid>, IDataModel<Guid>
    {
        [StringLength(128, MinimumLength = 32)]
        public string ApiToken { get; set; }

        [DataType(DataType.DateTime)]
        public DateTimeOffset? DateCreated { get; set; }

        [DataType(DataType.DateTime)]
        public DateTimeOffset? DateModified { get; set; }

        [StringLength(CommonLengths.Email)]
        public string UserCreated { get; set; }

        [StringLength(CommonLengths.Email)]
        public string UserModified { get; set; }
    }
}