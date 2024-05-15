//using ApiCoreCrudDepartamentos.Data;
//using ApiCoreCrudDepartamentos.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NSwag.Generation.Processors.Security;
using NSwag;
using Swashbuckle.AspNetCore.SwaggerUI;
using ApiTechRiders.Helpers;
using ApiTechRiders.Repositories;
using ApiTechRiders.Data;
using Hellang.Middleware.ProblemDetails;
using ApiTechRiders.Services;

var builder = WebApplication.CreateBuilder(args);

//ENABLE PROBLEM DETAILS
builder.Services.AddProblemDetails();

builder.Services.AddTransient<ApiImagenesService>();

// Add services to the container.
string connectionString =
    builder.Configuration.GetConnectionString("SqlLocal");
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
