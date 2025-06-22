using AspNetCore.Authentication.ApiKey;
using MeteorModApi.Services;
using MeteorModApi.Transformers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IPlayStatusService, PlayStatusService>(_ =>
    new PlayStatusService(builder.Configuration.GetValue<int>("MaxAgeInMinutes")));
builder.Services.AddSingleton<ISyncedServerService, SyncedSyncedServerService>();

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
            },
        };
    });

builder.Services.AddControllers();
builder.Services.AddOpenApi(options =>
{
    options.AddDocumentTransformer<ApiKeySecuritySchemeTransformer>();
});

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapOpenApi();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/openapi/v1.json", "v1");
    options.EnableTryItOutByDefault();
});

app.MapControllers();

app.Run();
