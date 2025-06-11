using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using Corp.Lib.CertificateAuthentication.Configuration;
using Corp.Lib.CertificateAuthentication.Services;
using Corp.Lib.CertificateAuthentication.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Certificate;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Https;
using Microsoft.Extensions.DependencyInjection;

namespace Corp.Lib.CertificateAuthentication.Extensions
{
	public static class ServiceCollectionExtensions
	{
		public static void AddCertificateAuthenticationService(this WebApplicationBuilder builder)
		{
			builder.Services.Configure<ClientCertificateSettings>(builder.Configuration.GetSection("ClientCertificateSettings"));

			// Require a certificate from any client sending a request.
			builder.WebHost.ConfigureKestrel(kestrel =>
			{
				kestrel.ConfigureHttpsDefaults(defaults =>
				{
					defaults.ClientCertificateMode = ClientCertificateMode.RequireCertificate;
				});
			});

			builder.Services.AddSingleton<IAuthenticationService, AuthenticationService>();

			builder.Services.AddAuthentication(CertificateAuthenticationDefaults.AuthenticationScheme).AddCertificate(options =>
			{
				options.Events = new CertificateAuthenticationEvents
				{
					OnCertificateValidated = context =>
					{
						var validationService = context.HttpContext.RequestServices.GetRequiredService<IAuthenticationService>();

						if (!validationService.IsValidClientCertificate(context.ClientCertificate))
						{
							context.Principal = null;
							
							context.Fail("Invalid client certificate.");
						}
						else
						{
							var claims = new[]
							{
								new Claim(
									ClaimTypes.NameIdentifier,
									context.ClientCertificate.GetNameInfo(X509NameType.SimpleName, false),
									ClaimValueTypes.String,
									context.Options.ClaimsIssuer),
								new Claim(
									ClaimTypes.Name,
									context.ClientCertificate.GetNameInfo(X509NameType.SimpleName, false),
									ClaimValueTypes.String,
									context.Options.ClaimsIssuer)
							};

							context.Principal = new ClaimsPrincipal(new ClaimsIdentity(claims, context.Scheme.Name));

							context.Success();
						}

						return Task.CompletedTask;
					}
				};
			});
		}

		public static void UseCertificateAuthenticationService(this WebApplication app)
		{
			app.UseAuthentication();
		}
	}
}
