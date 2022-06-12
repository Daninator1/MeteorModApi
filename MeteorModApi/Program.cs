using AspNetCore.Authentication.ApiKey;
using MeteorModApi.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IPlayStatusService, PlayStatusService>(_
    => new PlayStatusService(builder.Configuration.GetValue<int>("MaxAgeInMinutes")));

builder.Services.AddAuthentication(ApiKeyDefaults.AuthenticationScheme)
    .AddApiKeyInHeader(options =>
    {
        options.Realm = "MeteorModApi";
        options.KeyName = "Api-Key";
        options.Events = new ApiKeyEvents
        {
            OnValidateKey = context =>
            {
                if (context.ApiKey == builder.Configuration.GetValue<string>("ApiKey"))
                    context.ValidationSucceeded();
                else
                    context.ValidationFailed();

                return Task.CompletedTask;
            }
        };
    });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
    {
        Description = "API Key must be set in order to access the API.",
        Type = SecuritySchemeType.ApiKey,
        Name = "Api-Key",
        In = ParameterLocation.Header,
        
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "ApiKey" }
            },
            Array.Empty<string>()
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

//app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();