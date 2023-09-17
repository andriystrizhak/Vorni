using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eng_Flash_Cards_Learner;

[Table("AllWords")]
public partial class Word
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int WordId { get; set; }

    public string EngWord { get; set; } = null!;

    public string UaTranslation { get; set; } = null!;

    //[DefaultValue(0)]
    public int Rating { get; set; }

    //[DefaultValue(0)]
    public int Repetition { get; set; }

    public int Difficulty { get; set; }
}
