
using fh_family_experience_api.Interfaces;
using fh_family_experience_api.Repo;
using fh_family_experience_core.Interfaces;
using fh_family_experience_core.Services;
using System.Text.Json.Serialization;
using System.Text.Json;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IRepository, DBRepository>();

builder.Services.AddControllers();

builder.Services.AddMvc()
     .AddNewtonsoftJson(
          options =>
          {
              options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
          });

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
