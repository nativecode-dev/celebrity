namespace Celebrity.Models.Security
{
    using System.ComponentModel.DataAnnotations;
    using Core;

    public class LoginModel
    {
        [StringLength(CommonLengths.Email)]
        public string Login { get; set; }

        [Required]
        [StringLength(128)]
        public string Password { get; set; }
    }
}