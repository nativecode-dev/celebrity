namespace Celebrity.Services.Options
{
    public class AuthOpenId
    {
        public string CallbackUrl { get; set; }

        public string ClaimsIssuer { get; set; }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string Domain { get; set; }

        public string ResponseType { get; set; }

        public string Scope { get; set; }
    }
}