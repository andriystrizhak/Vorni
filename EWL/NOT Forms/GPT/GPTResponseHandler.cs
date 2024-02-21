using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eng_Flash_Cards_Learner.NOT_Forms.GPT
{
    public static class GptResponseHandler
    {
        public static List<(string, string)> Handle_FCGPTResponse(string response)
        {
            List<(string, string)>? result = null;
            try
            {
                 result = response
                    .Split('\n', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => s.Substring(3).Split(" / ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries))
                    .Select(wp => 
                    {
                        if (!wp[0].Contains("_"))
                            throw new Exception("There's no missing (underscores) in English sentence");
                        return (wp[0], wp[1]); 
                    })
                    .ToList();
            }
            catch
            {
                throw new ArgumentException("Wrong format of GPT-response");
            }
            return result;
        }
    }
}
