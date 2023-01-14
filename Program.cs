using OpenAI.API.Exp;
using OpenAI.API.Exp.Services;
using OpenAI.GPT3.Extensions;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddOpenAIService(settings =>
        {
            settings.ApiKey = "YOU_OPENAI_TOKEN";
        });
        services.AddHostedService<OpenAICompletion>();
        //services.AddHostedService<OpenAIImageService>();
    })
    .Build();

host.Run();
