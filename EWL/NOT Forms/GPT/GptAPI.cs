using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using Newtonsoft.Json;
using EWL;
using OpenAI.Managers;
using OpenAI.ObjectModels.RequestModels;
using OpenAI.ObjectModels;
using OpenAI;
using Eng_Flash_Cards_Learner.NOT_Forms.GPT;
using OpenAI.ObjectModels.ResponseModels;
using DevExpress.XtraSplashScreen;

namespace Eng_Flash_Cards_Learner.NOT_Forms
{
    public class GptAPI
    {
        public static event Action<string, IOverlaySplashScreenHandle> GPTResponseHandler;
        public static event Action<string, IOverlaySplashScreenHandle> GPTErrorHandler;

        static Label CurrentLabel { get; set; }

        const string MyApiKey = "КЛЮЧ"; //PROTECT

        const string PromptForTests = "Create forur options: first of them is a special word or phrase " +
            "and other three options may be slightly similar in meaning to the special word or phrase, " +
            "but not the same. Do not change special word or phrase. I'll send you several special words or phrases. " +
            "You have to do it with each of them and numerate answers. There's example with 'one' and 'apple' words:\r\n" +
            "1.\r\na) one\r\nb) seven\r\nc) zero\r\nd) one million\r\n\r\n2.\r\na) apple\r\nb) pear\r\nc) banana\r\nd) pumpkin";

        const string PromptForFC = "Create a short sentences for every special word where special word is missing. There's examble for 'one' and 'apple' words\r\n"
            + "1. I have only _____ apple left.\r\n2. I have a red _____ in my hand.";


        public static async void GetResponseAsStream(Label label, string[] words, GptPurpose purpose)
        {
            CurrentLabel = label;

            var api = GetOpenAIService();
            string prompt = GetPrompt(purpose);
            int maxTokens = words.Length * 20;

            IAsyncEnumerable<ChatCompletionCreateResponse> completionResult = null;

            try
            {

                completionResult = api.ChatCompletion.CreateCompletionAsStream(new ChatCompletionCreateRequest
                {
                    Messages = new List<ChatMessage>
                    {
                        ChatMessage.FromUser(PromptForTests + $"\r\nThere's the words:\r\n{string.Join("\r\n", words)}")
                    },
                    MaxTokens = maxTokens
                });
            }
            catch { }

            await foreach (var completion in completionResult)
            {
                if (completion.Successful)
                {
                    UpdateLabelText(completion.Choices.First().Message.Content);
                }
                else
                {
                    if (completion.Error == null)
                        throw new Exception("Unknown Error");

                    UpdateLabelText($"{completion.Error.Code}: {completion.Error.Message}");
                }
            }
        }

        public static async void GetResponse(string[] words, GptPurpose purpose, IOverlaySplashScreenHandle overlayPHandrer)
        {
            var api = GetOpenAIService();

            string prompt = GetPrompt(purpose);
            ChatCompletionCreateResponse completionResult = null;

            int maxTokens = words.Length * 20;

            try
            {
                completionResult = await api.ChatCompletion.CreateCompletion(new ChatCompletionCreateRequest
                {
                    Messages = new List<ChatMessage>
                    {
                        ChatMessage.FromUser(prompt + $"\r\nThere's the words:\r\n{string.Join("\r\n", words)}")
                    },
                    MaxTokens = maxTokens
                });
            }
            catch { }

            if (completionResult == null)
                GPTErrorHandler?.Invoke("ВКЛЮЧИ ІНЕТ", overlayPHandrer); //TEMP
            else if (completionResult.Successful)
                GPTResponseHandler?.Invoke(completionResult.Choices.First().Message.Content, overlayPHandrer);
            else
            {
                if (completionResult.Error == null)
                    GPTErrorHandler?.Invoke("Unknown Error", overlayPHandrer);

                GPTErrorHandler?.Invoke($"{completionResult.Error.Code}: {completionResult.Error.Message}", overlayPHandrer);
            }   
        }

        static OpenAIService GetOpenAIService()
        {
            var api = new OpenAIService(new OpenAiOptions()
            {
                ApiKey = MyApiKey,
            });
            api.SetDefaultModelId(Models.Gpt_3_5_Turbo_1106);
            return api;
        }

        static string GetPrompt(GptPurpose purpose)
            => purpose switch
            {
                GptPurpose.Test => PromptForTests,
                GptPurpose.FlashCards => PromptForFC,
                _ => ""
            };

        private static void UpdateLabelText(string text)
        {
            if (CurrentLabel.InvokeRequired)
                CurrentLabel.Invoke(new Action(() => CurrentLabel.Text += text));
            else
                CurrentLabel.Text = text;
        }
    }
}
