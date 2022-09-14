
using fh_family_experience_api.Interfaces;
using fh_family_experience_api.Repo;
using fh_family_experience_core.Interfaces;
using fh_family_experience_core.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IRepository, DBRepository>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
