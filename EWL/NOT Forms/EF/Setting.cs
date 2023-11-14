﻿using System;
using System.Collections.Generic;

namespace EWL;

public partial class Setting
{
    public int SettingsId { get; set; }

    public int WordCountToLearn { get; set; }

    public int CurrentDifficulty { get; set; }

    public bool WasLaunched { get; set; }

    public int WordAddingMode { get; set; }

    public int CurrentCategoryId { get; set; }

    public virtual Category CurrentCategory { get; set; } = null!;
}
