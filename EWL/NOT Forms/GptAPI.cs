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

namespace Eng_Flash_Cards_Learner.NOT_Forms
{
    public class GptAPI
    {
        static Label CurrentLabel { get; set; }
        public static async void PIPI(Label label, string prompt = "")
        {
            CurrentLabel = label;
            var api = new OpenAIService(new OpenAiOptions()
            {
                ApiKey = "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", //PROTECT
            });

            /////////////////////////////////////////////////////////////////////

            api.SetDefaultModelId(Models.Gpt_3_5_Turbo_16k);

            /////////////////////////////////////////////////////////////////////

            var completionResult = api.ChatCompletion.CreateCompletionAsStream(new ChatCompletionCreateRequest
            {
                Messages = new List<ChatMessage>
                {
                    ChatMessage.FromSystem("Create a short sentence where special word is missing. \r\nBelow are four answer options. Randomly only one of them shoud be correct - the special word. Trying to not change special word.\r\nAnd at the end add the letter of correct answer. \r\nThere's example with 'apple' word:\r\n\r\n'I enjoy eating _____ every day.\r\n\r\nA) table\r\nB) boat\r\nC) apple\r\nD) love\r\n\r\nC'\r\n\r\nI'll send you only special word"),
                    ChatMessage.FromUser("bother")
                },
                MaxTokens = 70
            });

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
            ///////////////////////////////////////////////////////////////////////////

            //var completionResult = await openAiService.ChatCompletion.CreateCompletion(new ChatCompletionCreateRequest
            //{
            //    Messages = new List<ChatMessage>
            //    {
            //        ChatMessage.FromUser("Розкажи про Ілона Маска")
            //    },
            //    Model = Models.ChatGpt3_5Turbo
            //});
            //
            //if (completionResult.Successful)
            //{
            //    form.label22.Text = completionResult.Choices.First().Message.Content;
            //}
            //else
            //{
            //    if (completionResult.Error == null)
            //        throw new Exception("Unknown Error");
            //
            //    form.label22.Text = $"{completionResult.Error.Code}: {completionResult.Error.Message}";
            //}
        }


        private static void UpdateLabelText(string text)
        {
            if (CurrentLabel.InvokeRequired)
            {
                CurrentLabel.Invoke(new Action(() => CurrentLabel.Text += text));
            }
            else
            {
                CurrentLabel.Text = text;
            }
        }
    }
}
