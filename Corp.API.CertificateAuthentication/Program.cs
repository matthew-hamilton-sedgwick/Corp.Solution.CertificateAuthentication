using Asp.Versioning;
using Corp.Lib.CertificateAuthentication.Extensions;
using Corp.Lib.Logging.Extensions;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Text.Json.Serialization;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddLogging(false);
builder.AddCertificateAuthenticationService();

builder.Services.AddApiVersioning(options =>
{
	options.AssumeDefaultVersionWhenUnspecified = true;
	options.DefaultApiVersion = new ApiVersion(1, 0);
});

builder.Services.AddControllers(options => options.OutputFormatters.RemoveType<HttpNoContentOutputFormatter>()).AddJsonOptions(options =>
{
	options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
	options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.AddSwaggerWithLogging();

var app = builder.Build();

app.UseLogging(false);
app.UseCertificateAuthenticationService();

app.UseSwaggerWithLogging();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
