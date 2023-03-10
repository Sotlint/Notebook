using System;
using System.Collections.Generic;

namespace Notebook;

public partial class AddressDatum
{
    public long AdId { get; set; }

    public long? FioId { get; set; }

    public string? City { get; set; }

    public string? Street { get; set; }

    public string? Floor { get; set; }

    public string? ApartNumber { get; set; }

    public virtual Fiodatum? Fio { get; set; }
}
