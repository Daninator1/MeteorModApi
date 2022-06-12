using AspNetCore.Authentication.ApiKey;
using MeteorModApi.Services;

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
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();