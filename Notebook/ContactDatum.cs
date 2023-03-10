using System;
using System.Collections.Generic;

namespace Notebook;

public partial class ContactDatum
{
    public long CdId { get; set; }

    public long? FioId { get; set; }

    public string? Telephone { get; set; }

    public string? Mail { get; set; }

    public virtual Fiodatum? Fio { get; set; }
}
