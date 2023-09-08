using System;
using System.Collections.Generic;

namespace Eng_Flash_Cards_Learner;

public partial class WordCategory
{
    public long WordId { get; set; }

    public long CategoryId { get; set; }

    public byte[] AddedAt { get; set; } = null!;

    public virtual Category Category { get; set; } = null!;

    public virtual AllWord Word { get; set; } = null!;
}
