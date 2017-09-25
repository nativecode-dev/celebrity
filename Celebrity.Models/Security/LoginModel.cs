namespace Celebrity.Models.Security
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;
    using Core;

    [DataContract]
    public class LoginModel : Model
    {
        [DataMember]
        [DataType(DataType.EmailAddress)]
        [StringLength(CommonLengths.Email)]
        [DisplayName(nameof(LoginModel.Login))]
        public string Login { get; set; }

        [Required]
        [DataMember]
        [DataType(DataType.Password)]
        [StringLength(CommonLengths.Password)]
        [DisplayName(nameof(LoginModel.Password))]
        public string Password { get; set; }
    }
}