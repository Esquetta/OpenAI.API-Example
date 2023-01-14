using OpenAI.GPT3.Interfaces;
using OpenAI.GPT3.ObjectModels;
using OpenAI.GPT3.ObjectModels.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAI.API.Exp.Services
{
    public class OpenAIImageService : BackgroundService
    {
        private readonly IOpenAIService openAIService;
        public OpenAIImageService(IOpenAIService openAIService)
        {
            this.openAIService = openAIService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (true)
            {
                Console.WriteLine("Resim Konusu: ");

                var response = await openAIService.Image.CreateImage(new ImageCreateRequest()
                {
                    Prompt = Console.ReadLine(),
                    Size = StaticValues.ImageStatics.Size.Size1024,
                    N = 5,
                    ResponseFormat = StaticValues.ImageStatics.ResponseFormat.Url,
                    User="Test"
                });

                Console.WriteLine(string.Join("\n", response.Results.Select(x => x.Url)));
            }
        }
    }
}
