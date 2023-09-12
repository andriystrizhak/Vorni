using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Eng_Flash_Cards_Learner;

public partial class AllWord
{
    public int WordId { get; set; }

    public string EngWord { get; set; } = null!;

    public string UaTranslation { get; set; } = null!;

    //[DefaultValue(0)]
    public int Rating { get; set; }

    //[DefaultValue(0)]
    public int Repetition { get; set; }

    public int Difficulty { get; set; }
}
