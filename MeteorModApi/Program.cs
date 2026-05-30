using AspNetCore.Authentication.ApiKey;
using MeteorModApi.Services;
using MeteorModApi.Transformers;
using Scalar.AspNetCore;

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
builder.Services.AddOpenApi(options => { options.AddDocumentTransformer(new ApiKeySecuritySchemeTransformer()); });

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapOpenApi();
app.MapScalarApiReference(options =>
{
    options.DisableAgent();
    options.DisableMcp();
    options.HideClientButton();
    options.EnablePersistentAuthentication();
});

app.MapControllers();

app.Run();
