using System.Security.Cryptography.X509Certificates;

namespace Corp.Lib.CertificateAuthentication.Services.Interfaces
{
    public interface IAuthenticationService
    {
        bool IsValidClientCertificate(X509Certificate2 certificate);
    }
}
