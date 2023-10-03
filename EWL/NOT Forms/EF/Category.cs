using System;
using System.Collections.Generic;

namespace EWL;

public partial class Category
{
    public int CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public bool CanBeDeleted { get; set; } = true;

    public bool Deleted { get; set; }

    public DateTime DeletedAt { get; set; }

    public virtual ICollection<Setting> Settings { get; set; } = new List<Setting>();
}
