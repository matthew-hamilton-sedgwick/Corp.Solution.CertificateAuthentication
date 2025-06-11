//using System.Configuration;
using Corp.Lib.CertificateAuthentication.Services.Interfaces;
using System.Security.Cryptography.X509Certificates;
//using Corp.Lib.CertificateAuthentication.Configuration;
//using Microsoft.Extensions.Options;

namespace Corp.Lib.CertificateAuthentication.Services
{
	public class AuthenticationService/*(IOptions<ClientCertificateSettings> options)*/ : IAuthenticationService
	{
		//private readonly ClientCertificateSettings _ClientCertificateSettings = options.Value;

		public bool IsValidClientCertificate(X509Certificate2 clientCertificate)
		{
			return false;

			//if (clientCertificate == null!)
			//{
			//	var error = new ConfigurationErrorsException("Missing certificate or certificate not sent by client.");

			//	//Corp.Lib.Logging.Logger.Log.Error(error, "Certificate validation failed. Missing certificate or certificate not sent by client.");

			//	throw error;
			//}

			//if (_ClientCertificateSettings == null! || _ClientCertificateSettings.AllowedCertificates == null! || !_ClientCertificateSettings.AllowedCertificates.ToList().Any())
			//{
			//	var error = new ConfigurationErrorsException("Certificate configuration missing. Check AppSettings.");

			//	//Corp.Lib.Logging.Logger.Log.Error(error, "Certificate validation failed. Certificate configuration missing. Check AppSettings.");

			//	throw error;
			//}

			//if (_ClientCertificateSettings.AllowedCertificates.Any(cert => string.IsNullOrEmpty(cert.Subject)))
			//{
			//	var error = new ConfigurationErrorsException("Certificate configuration missing Subject. Check AppSettings.");

			//	//Corp.Lib.Logging.Logger.Log.Error(error, "Certificate validation failed. Certificate configuration missing Subject. Check AppSettings.");

			//	throw error;
			//}

			//if (_ClientCertificateSettings.AllowedCertificates.Any(cert => string.IsNullOrEmpty(cert.Issuer)))
			//{
			//	var error = new ConfigurationErrorsException("Certificate configuration missing Subject. Check AppSettings.");

			//	//Corp.Lib.Logging.Logger.Log.Error(error, "Certificate validation failed. Certificate configuration missing Issuer. Check AppSettings.");

			//	throw error;
			//}

			//// 1. Check time validity of certificate.
			//if (DateTime.Compare(DateTime.UtcNow, clientCertificate.NotBefore) < 0 || DateTime.Compare(DateTime.UtcNow, clientCertificate.NotAfter) > 0)
			//{
			//	//Corp.Lib.Logging.Logger.Log.Warning($"Certificate with thumbprint {clientCertificate.Thumbprint} is expired.");

			//	return false;
			//}

			//// 2. Check subject name of certificate.
			//var foundSubject = false;

			//var certSubjectData = clientCertificate.Subject.Split([','], StringSplitOptions.RemoveEmptyEntries);

			//if (certSubjectData.Any(certSubject => _ClientCertificateSettings.AllowedCertificates.Any(cert => cert.Subject.Equals(certSubject.Trim(), StringComparison.InvariantCultureIgnoreCase))))
			//{
			//	foundSubject = true;
			//}

			//if (!foundSubject)
			//{
			//	//Corp.Lib.Logging.Logger.Log.Warning($"Certificate with thumbprint {clientCertificate.Thumbprint} does not have a matching Subject.");

			//	return false;
			//}

			//// 3. Check issuer name of certificate.
			//var certIssuerData = clientCertificate.Issuer.Split([','], StringSplitOptions.RemoveEmptyEntries);

			//var foundIssuer = certIssuerData.Any(issuerData => _ClientCertificateSettings.AllowedCertificates.Any(cert => cert.Issuer.Equals(issuerData.Trim(), StringComparison.InvariantCultureIgnoreCase)));

			//if (!foundIssuer)
			//{
			//	//Corp.Lib.Logging.Logger.Log.Warning($"Certificate with thumbprint {clientCertificate.Thumbprint} does not have a matching Issuer.");

			//	return false;
			//}

			//// Check if the Certificate exists in the server personal cert store.
			//if (_ClientCertificateSettings.CheckThumbprintInCertStore)
			//{
			//	var store = new X509Store(StoreName.My, StoreLocation.LocalMachine);

			//	try
			//	{
			//		store.Open(OpenFlags.OpenExistingOnly | OpenFlags.ReadOnly);

			//		var certs = store.Certificates.Find(X509FindType.FindByThumbprint, clientCertificate.Thumbprint, true);

			//		if (certs.Count == 0)
			//		{
			//			//Corp.Lib.Logging.Logger.Log.Warning("Invalid client certificate. The thumbprint does not match with a certificate in the certificate store. {@ClientCertificate}", clientCertificate);

			//			return false;
			//		}
			//	}
			//	//catch (Exception ex)
			//	//{
			//	//	Corp.Lib.Logging.Logger.Log.Error(ex, "An exception occurred searching for the client certificate in the certificate store. {@ClientCertificate}", clientCertificate);

			//	//	throw;
			//	//}
			//	finally
			//	{
			//		store.Close();

			//		store.Dispose();
			//	}
			//}

			//return true;
		}
	}
}
