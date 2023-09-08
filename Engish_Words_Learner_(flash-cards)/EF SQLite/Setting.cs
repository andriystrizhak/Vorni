using System;
using System.Collections.Generic;

namespace Eng_Flash_Cards_Learner;

public partial class Setting
{
    public long SettingsId { get; set; }

    public long WordCountToLearn { get; set; }

    public long WasLaunched { get; set; }

    public long WordAddingMode { get; set; }

    public long CurrentCategoryId { get; set; }

    public virtual Category CurrentCategory { get; set; } = null!;
}
