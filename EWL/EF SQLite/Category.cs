using System;
using System.Collections.Generic;

namespace Eng_Flash_Cards_Learner;

public partial class Category
{
    public long CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public bool CanBeDeleted { get; set; }

    public bool Deleted { get; set; }

    public DateTime DeletedAt { get; set; }

    public virtual ICollection<Setting> Settings { get; set; } = new List<Setting>();
}
