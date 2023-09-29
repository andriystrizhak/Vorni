using System;
using System.Collections.Generic;

namespace EWL;

public partial class WordCategory
{
    public int WordId { get; set; }

    public int CategoryId { get; set; }

    public DateTime AddedAt { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual Word Word { get; set; } = null!;
}
