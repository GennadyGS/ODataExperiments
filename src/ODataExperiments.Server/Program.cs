using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.OData.Formatter.Serialization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Newtonsoft.Json;
using ODataExperiments.Server.Models;
using ODataExperiments.Server.Serializers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddCors(options =>
        options.AddDefaultPolicy(policy => policy.WithOrigins("*")))
    .AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
        options.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
        options.SerializerSettings.FloatParseHandling = FloatParseHandling.Decimal;
        options.UseCamelCasing(true);
    })
    .AddOData(options =>
    {
        options.AddRouteComponents(
            "odata",
            GetEdmModel(),
            services => services
                .AddSingleton<ODataPrimitiveSerializer, RemoveTypeAnnotationsPrimitiveSerializer>()
        );
        options.EnableQueryFeatures();
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.UseODataRouteDebug();

app.UsePathBase(new PathString("/api"));
await app.RunAsync();

static IEdmModel GetEdmModel()
{
    var builder = new ODataConventionModelBuilder();
    builder.EnableLowerCamelCase();
    builder.EntitySet<Record>("Records");
    builder.EntitySet<City>("Cities");
    return builder.GetEdmModel();
}
