namespace Corp.Lib.CertificateAuthentication.Configuration
{
    public class ClientCertificateSettings
    {
        public bool CheckThumbprintInCertStore { get; set; }

        public List<ClientCertificate> AllowedCertificates { get; set; } = null!;
    }

    public class ClientCertificate
    {
        public string Subject { get; set; } = null!;

        public string Issuer { get; set; } = null!;
    }
}
