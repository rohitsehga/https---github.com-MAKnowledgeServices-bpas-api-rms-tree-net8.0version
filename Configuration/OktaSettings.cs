namespace ResourceRequestService.Configuration
{
    public class OktaSettings
    {
        public string Issuer { get; set; }
        public string AssertionConsumerServiceUrl { get; set; }
        public string SamlEndPoint { get; set; }
        public string RedirectUrl { get; set; }
    }
}
