using Refit;

namespace Corp.Web.CertificateAuthentication.Services
{
	public interface IRefitService
	{
		[Get("/WeatherForecast")]
		public Task<IEnumerable<WeatherForecast>> GetAsync();
	}
}
