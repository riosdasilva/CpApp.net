namespace ElsaConcept.Configurations
{
    public class TokenConfiguration
    {
        public string Audience { get; set; } = "ExempleAudience";
        public string Issuer   { get; set; } = "ExempleIssuer";
        public string Secret { get; set; } = "MY_SUPER_SECRET_KEY";
        public int Minutes { get; set; } = 60;
        public int DaysToExpiry { get; set; } = 7;
    }
}
