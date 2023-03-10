using System;
using System.Collections.Generic;

namespace Notebook;

public partial class BirthdayDatum
{
    public long BdId { get; set; }

    public long? FioId { get; set; }

    public long? Day { get; set; }

    public long? Month { get; set; }

    public long? Year { get; set; }

    public virtual Fiodatum? Fio { get; set; }
}
