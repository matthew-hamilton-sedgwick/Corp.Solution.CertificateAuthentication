namespace Corp.Web.CertificateAuthentication.Services
{
	public class Service(IRefitService refitService) : IService
	{
		public Task<IEnumerable<WeatherForecast>> GetAsync()
		{
			return refitService.GetAsync();
		}
	}
}
