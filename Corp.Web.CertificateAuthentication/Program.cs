using Corp.Lib.Logging.Extensions;
using Corp.Lib.Refit.Extensions;
using Corp.Web.CertificateAuthentication.Services;
using System.Text.Json.Serialization;
using Corp.Web.CertificateAuthentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddLogging(true);

var appSettings = builder.Configuration.GetSection("AppSettings").Get<AppSettings>()!;

var certificateSettings = builder.Configuration.GetSection("CertificateSettings").Get<CertificateSettings>()!;

builder.AddRefitClient<IService, Service, IRefitService>("Corp.API.CertificateAuthentication", appSettings.ServiceBaseAddress, certificateSettings.Path, certificateSettings.Password);

builder.Services.AddControllersWithViews()
	.AddJsonOptions(options =>
	{
		options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());	// Required for logging to recognize the Level configuration element (Verbose, Debug, Information, Warn, Error, or Critical).
		options.JsonSerializerOptions.PropertyNamingPolicy = null;	// Required for DevExpress controls that get data from a controller method or API.
	});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
