using SecurityPlayground.Infrastructure;
using SecurityPlayground.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApiServices();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(options => options.AddPolicy("ApiCorsPolicy", corsPolicyBuilder =>
{
    corsPolicyBuilder.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    // Initialise and seed database
    using var scope = app.Services.CreateScope();

    var initialiser = scope.ServiceProvider.GetRequiredService<CertificateContextInitialiser>();
    await initialiser.InitialiseAsync();
    //await initialiser.SeedAsync();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("ApiCorsPolicy");

app.MapControllers();

app.Run();