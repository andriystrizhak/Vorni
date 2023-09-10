using System;
using System.Collections.Generic;

namespace Eng_Flash_Cards_Learner;

public partial class Setting
{
    public long SettingsId { get; set; }

    public int WordCountToLearn { get; set; }

    public bool WasLaunched { get; set; }

    public int WordAddingMode { get; set; }

    public long CurrentCategoryId { get; set; }

    public virtual Category CurrentCategory { get; set; } = null!;
}
