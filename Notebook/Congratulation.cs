using System;
using System.Collections.Generic;

namespace Notebook;

public partial class Congratulation
{
    public long CId { get; set; }

    public long? FioId { get; set; }

    public string? Text { get; set; }

    public long? Day { get; set; }

    public long? Month { get; set; }

    public long? Year { get; set; }

    public virtual Fiodatum? Fio { get; set; }
}
