using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eng_Flash_Cards_Learner.NOT_Forms.GPT
{
    public static class GPTResponseHandler
    {
        public static List<string> Handle_FCGPTResponse(string response)
        {
            List<string> result = response.Split('\n', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).Select(s => s.Substring(3)).ToList();
            return result;
        }
    }
}
