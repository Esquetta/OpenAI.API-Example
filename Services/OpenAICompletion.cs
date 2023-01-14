using OpenAI.GPT3.Interfaces;
using OpenAI.GPT3.ObjectModels;
using OpenAI.GPT3.ObjectModels.RequestModels;
using OpenAI.GPT3.ObjectModels.ResponseModels;

namespace OpenAI.API.Exp.Services
{
    public class OpenAICompletion : BackgroundService
    {
        private readonly IOpenAIService openAIService;

        public OpenAICompletion(IOpenAIService openAIService)
        {
            this.openAIService = openAIService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (true)
            {
                Console.Write("Soru:");
                CompletionCreateRequest resquest = new CompletionCreateRequest()
                {
                    Prompt = Console.ReadLine(),//Question
                    MaxTokens = 1000//Answer character limit of question
                    

                };
                CompletionCreateResponse response = await openAIService.Completions.CreateCompletion(resquest,Models.TextDavinciV3);

                Console.WriteLine(response.Choices.FirstOrDefault());
            }
        }
    }
}
