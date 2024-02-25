using MMLib.SwaggerForOcelot.DependencyInjection;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("ocelot.json", false)
    .AddEnvironmentVariables();

//builder.Configuration.AddOcelotWithSwaggerSupport(builder.Environment);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerForOcelot(builder.Configuration,
    (o) =>
    {
        o.GenerateDocsForGatewayItSelf = true;
    });

builder.Services.AddOcelot(builder.Configuration);
//builder.Configuration.AddOcelot(builder.Environment);

var app = builder.Build();

// Configure the HTTP request pipeline.


app.UseSwaggerForOcelotUI(options =>
{
    options.PathToSwaggerGenerator = "/swagger/docs";
});

app.UseOcelot();

app.Run();

