using System;
using System.Collections.Generic;

namespace Eng_Flash_Cards_Learner;

public partial class Category
{
    public long CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public byte[] CreatedAt { get; set; } = null!;

    public long CanBeDeleted { get; set; }

    public long Deleted { get; set; }

    public byte[] DeletedAt { get; set; } = null!;

    public virtual ICollection<Setting> Settings { get; set; } = new List<Setting>();
}
