using System;
using System.Collections.Generic;

namespace Eng_Flash_Cards_Learner;

public partial class AllWord
{
    public long WordId { get; set; }

    public string EngWord { get; set; } = null!;

    public string UaTranslation { get; set; } = null!;

    public long Rating { get; set; }

    public long Repetition { get; set; }
}
