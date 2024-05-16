using NSwag.Generation.Processors.Security;
using Hellang.Middleware.ProblemDetails;
using Swashbuckle.AspNetCore.SwaggerUI;
using Microsoft.EntityFrameworkCore;
using NSwag;
using Microsoft.OpenApi.Models;
using ApiTechRiders.Repositories;
using ApiTechRiders.Helpers;
using ApiTechRiders.Data;

var builder = WebApplication.CreateBuilder(args);

//ENABLE PROBLEM DETAILS
builder.Services.AddProblemDetails();

// Add services to the container.
string connectionString =
    builder.Configuration.GetConnectionString("SqlDesarrolloAzure");
builder.Services.AddTransient<RepositoryTechRiders>();
builder.Services.AddDbContext<TechRidersContext>
    (options => options.UseSqlServer(connectionString));

builder.Services.AddEndpointsApiExplorer();

// REGISTRAMOS SWAGGER COMO SERVICIO
builder.Services.AddOpenApiDocument(document =>
{
    document.Title = "Api TechRiders";
    document.Description = "Api TechRiders.  Proyecto Alumnos 2023";
    // CONFIGURAMOS LA SEGURIDAD JWT PARA SWAGGER,
    // PERMITE AÑADIR EL TOKEN JWT A LA CABECERA.
    document.AddSecurity("JWT", Enumerable.Empty<string>(),
        new NSwag.OpenApiSecurityScheme
        {
            Type = OpenApiSecuritySchemeType.ApiKey,
            Name = "Authorization",
            In = OpenApiSecurityApiKeyLocation.Header,
            Description = "Copia y pega el Token en el campo 'Value:' así: Bearer {Token JWT}."
        }
    );
    document.OperationProcessors.Add(
    new AspNetCoreOperationSecurityScopeProcessor("JWT"));
});
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));
HelperToken helper = new HelperToken(builder.Configuration);
builder.Services.AddTransient<HelperTokenPass>();
//AÑADIMOS AUTENTIFICACION A NUESTRO SERVICIO
builder.Services.AddAuthentication(helper.GetAuthOptions())
    .AddJwtBearer(helper.GetJwtOptions());

builder.Services.AddTransient<HelperToken>(x => helper);
builder.Services.AddTransient<HelperFilesManager>();
builder.Services.AddTransient<HelperPathProvider>();

builder.Services.AddControllers();

var app = builder.Build();

app.UseProblemDetails();
app.UseOpenApi();

if (app.Environment.IsDevelopment())
{

}
app.UseSwaggerUI(options =>
{
    options.InjectStylesheet("/css/bootstrap.css");
    options.InjectStylesheet("/css/material3x.css");
    options.SwaggerEndpoint(
        url: "/swagger/v1/swagger.json", name: "Api TechRiders Proyecto");
    options.RoutePrefix = "";
    options.DocExpansion(DocExpansion.None);
});
app.UseCors("corsapp");

app.UseHttpsRedirection();
app.UseRouting();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();

//app.MapControllers();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
