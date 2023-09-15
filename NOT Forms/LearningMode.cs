using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eng_Flash_Cards_Learner.Logic
{
    /// <summary>
    /// Визначає яка форма відкриватиметься після налаштувальної
    /// </summary>
    enum LearningMode
    {
        /// <summary>
        /// Just close form
        /// </summary>
        None,
        DataBase,
        NewTxtFiles,
        OldTxtFiles
    }
}
